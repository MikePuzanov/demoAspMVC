using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public interface IProductService : IBaseService
{
    Task<T> CreateProductAsync<T>(ProductDTO productDto);
    Task<T> DeleteProductAsync<T>(long id);
    Task<T> GetAllProductAsync<T>();
    Task<T> GetProductByIdAsync<T>(long id);
    Task<T> UpdateProductAsync<T>(ProductDTO productDto);
}