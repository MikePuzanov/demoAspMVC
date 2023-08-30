using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public interface IProductService : IBaseService
{
    Task<T> CreateProductAsync<T>(ProductDTO productDto, string token);
    Task<T> DeleteProductAsync<T>(long id, string token);
    Task<T> GetAllProductAsync<T>(string token);
    Task<T> GetProductByIdAsync<T>(long id, string token);
    Task<T> UpdateProductAsync<T>(ProductDTO productDto, string token);
}