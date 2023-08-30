using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public interface IAuthService : IBaseService
{
    Task<T> LoginUserAsync<T>(LoginAuth model, string token);
    Task<T> RegisterUserAsync<T>(string token);
    Task<T> LogoutUserAsync<T>(string token);
}