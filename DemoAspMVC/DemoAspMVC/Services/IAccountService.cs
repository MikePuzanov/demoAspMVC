using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public interface IAccountService : IBaseService
{
    Task<T> LoginUserAsync<T>(Login model);
    Task<T> RegisterUserAsync<T>();
    Task<T> LogoutUserAsync<T>();
}