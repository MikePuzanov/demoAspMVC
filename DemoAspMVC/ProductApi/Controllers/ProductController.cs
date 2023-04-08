using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Models.DTO;
using ProductApi.Repository;

namespace ProductApi.Controllers;

[Route("api/products")]
public class ProductController : ControllerBase
{
    private ResponseDTO _response;
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _response = new ResponseDTO();
        _repository = repository;
    }

    [HttpGet]
    public async Task<object> GetAll()
    {
        try
        {
            var products = await _repository.GetProducts();
            _response.Result = products;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpGet]
    //[Authorize (Roles = "User")]
    //[Authorize (Roles = "Admin")]
    [Route("{id}")]
    public async Task<object> Get(long id)
    {
        try
        {
            var products = await _repository.GetProductById(id);
            _response.Result = products;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpPost]
    public async Task<object> Create([FromBody] ProductDTO productDto)
    {
        try
        {
            var model = await _repository.CreateOrUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpPut]
    public async Task<object> Update([FromBody] ProductDTO productDto)
    {
        try
        {
            var model = await _repository.CreateOrUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<object> Delete(long id)
    {
        try
        {
            var isSuccess = await _repository.DeleteProduct(id);
            _response.Result = isSuccess;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
}