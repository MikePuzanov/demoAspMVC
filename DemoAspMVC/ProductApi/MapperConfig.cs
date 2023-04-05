using AutoMapper;
using ProductApi.Models;
using ProductApi.Models.DTO;

namespace ProductApi;

public class MapperConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mapperCfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductDTO>();
            cfg.CreateMap<ProductDTO, Product>();
        });
        return mapperCfg;
    }
}