using Demo.Utils;
using DemoAspMVC;
using DemoAspMVC.Services;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProductService, ProductService>();
Cfg.ProductApiBase = builder.Configuration.GetSection("ServiceUrl").GetSection("ProductApi").Value;
builder.Services.AddScoped<IProductService, ProductService>();

/*builder.Services.AddHttpClient<IAccountService, AccountService>();
Cfg.AccountApiBase = builder.Configuration.GetSection("ServiceUrl").GetSection("AccountApi").Value;
builder.Services.AddScoped<IAccountService, AccountService>();*/
builder.Services.AddHttpClient<IAuthService, AuthService>();
Cfg.AccountApiBase = builder.Configuration.GetSection("ServiceUrl").GetSection("AuthApi").Value;
builder.Services.AddScoped<IAuthService, AuthService>();







var authSettings  = builder.Configuration.GetSection("Auth").Get<AuthOptions>();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("Cookies", options => options.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        IdentityModelEventSource.ShowPII = true;
        options.RequireHttpsMetadata = false;
        options.Authority = Cfg.AccountApiBase;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "demo";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        
        options.Configuration = new OpenIdConnectConfiguration();
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("demo");
        options.SaveTokens = true;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "demo");
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();