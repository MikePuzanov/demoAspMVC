using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public class AccountService : BaseService, IAccountService
{
    private readonly IHttpClientFactory _clientFactory;
    
    public AccountService(IHttpClientFactory clientFactory) : base(clientFactory)
    { 
        _clientFactory = clientFactory;
    }


    public async Task<T> LoginUserAsync<T>(Login model, string token)
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