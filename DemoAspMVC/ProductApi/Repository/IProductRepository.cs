using ProductApi.Models.DTO;

namespace ProductApi.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(long id);
    Task<ProductDTO> CreateOrUpdateProduct(ProductDTO productDto);
    Task<bool> DeleteProduct(long id);
}