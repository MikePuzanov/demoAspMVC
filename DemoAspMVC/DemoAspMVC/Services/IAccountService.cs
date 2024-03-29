using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public interface IAccountService : IBaseService
{
    Task<T> LoginUserAsync<T>(Login model, string token);
    Task<T> RegisterUserAsync<T>(string token);
    Task<T> LogoutUserAsync<T>(string token);
}