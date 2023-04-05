using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductApi.DbContext;
using ProductApi.Models;
using ProductApi.Models.DTO;

namespace ProductApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public ProductRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsList = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductDTO>>(productsList);
    }

    public async Task<ProductDTO> GetProductById(long id)
    {
        var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> CreateOrUpdateProduct(ProductDTO productDto)
    {
        var product = _mapper.Map<ProductDTO, Product>(productDto);
        if (product.Id > 0)
        {
            _context.Products.Update(product);
        }
        else
        {
            await _context.Products.AddAsync(product);
        }
        await _context.SaveChangesAsync();
        return _mapper.Map<Product, ProductDTO>(product);
    }

    public async Task<bool> DeleteProduct(long id)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}