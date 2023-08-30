using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly IHttpClientFactory _clientFactory;
    
    public AuthService(IHttpClientFactory httpClient, IHttpClientFactory clientFactory) : base(httpClient)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> LoginUserAsync<T>(LoginAuth model, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = Cfg.ApiType.POST,
            Data = model,
            Url = Cfg.AccountApiBase + "/api/account/login",
            AccesToken = token
        });
    }

    public Task<T> RegisterUserAsync<T>(string token)
    {
        throw new NotImplementedException();
    }

    public Task<T> LogoutUserAsync<T>(string token)
    {
        throw new NotImplementedException();
    }
}