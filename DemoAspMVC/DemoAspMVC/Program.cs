using Demo.Utils;
using DemoAspMVC;
using DemoAspMVC.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProductService, ProductService>();
Cfg.ProductApiBase = builder.Configuration.GetSection("ServiceUrl").GetSection("ProductApi").Value;
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpClient<IAccountService, AccountService>();
Cfg.AccountApiBase = builder.Configuration.GetSection("ServiceUrl").GetSection("AccountApi").Value;
builder.Services.AddScoped<IAccountService, AccountService>();


var authSettings  = builder.Configuration.GetSection("Auth").Get<AuthOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:5230/";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authSettings.Issuer,

            ValidateAudience = true,
            ValidAudience = authSettings.Audience,

            ValidateLifetime = true,

            IssuerSigningKey = authSettings.GetSymmetricSecuriryKey(),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddAuthorization();

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