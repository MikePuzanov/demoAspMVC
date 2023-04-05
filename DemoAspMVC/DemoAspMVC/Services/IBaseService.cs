using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public interface IBaseService : IDisposable
{
    ResponseDTO responseModel { get; set; }
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}