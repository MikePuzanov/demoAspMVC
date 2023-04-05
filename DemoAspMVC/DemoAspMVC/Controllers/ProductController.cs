using DemoAspMVC.Models;
using DemoAspMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoAspMVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
        var list = new List<ProductDTO>();
        var response = await _productService.GetAllProductAsync<ResponseDTO>();
        if (response is { IsSuccess: true })
        {
            list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
        }
        return View(list);
    }
    
    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductCreate(ProductDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProductAsync<ResponseDTO>(model);
            if (response is { IsSuccess: true })
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
        return View(model);
    }
    
    public async Task<IActionResult> ProductEdit(long productId)
    {
        var response = await _productService.GetProductByIdAsync<ResponseDTO>(productId);
        if (response is { IsSuccess: true })
        {
            var model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
            return View(model);
        }

        return NotFound();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductEdit(ProductDTO model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.UpdateProductAsync<ResponseDTO>(model);
            if (response is { IsSuccess: true })
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
        return View(model);
    }

    public async Task<IActionResult> ProductDelete(ProductDTO model)
    {
        var response = await _productService.DeleteProductAsync<ResponseDTO>(model.Id);
        if (response is { IsSuccess: true })
        {
            return RedirectToAction(nameof(ProductIndex));
        }

        return View(model);
    }
    

}