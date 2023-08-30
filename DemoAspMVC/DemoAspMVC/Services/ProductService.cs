using DemoAspMVC.Models;

namespace DemoAspMVC.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    
    public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
    { 
        _clientFactory = clientFactory;
    }

    public async Task<T> GetAllProductAsync<T>(string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = Cfg.ApiType.GET,
            Url = Cfg.ProductApiBase + "/api/products/",
            AccesToken = token
        });
    }

    public async Task<T> GetProductByIdAsync<T>(long id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = Cfg.ApiType.GET,
            Url = Cfg.ProductApiBase + "/api/products/" + id,
            AccesToken = token
        });
    }

    public async Task<T> CreateProductAsync<T>(ProductDTO productDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = Cfg.ApiType.POST,
            Data = productDto,
            Url = Cfg.ProductApiBase + "/api/products/",
            AccesToken = token
        });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDTO productDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = Cfg.ApiType.PUT,
            Data = productDto,
            Url = Cfg.ProductApiBase + "/api/products/",
            AccesToken = token
        });
    }

    public async Task<T> DeleteProductAsync<T>(long id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = Cfg.ApiType.DELETE,
            Url = Cfg.ProductApiBase + "/api/products/" + id,
            AccesToken = token
        });
    }
}