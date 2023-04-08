using AccountApi.Models;
using AccountApi.Models.DTO;
using AutoMapper;

namespace AccountApi;

public class MapperConfig
{
    public static MapperConfiguration RegisterMap()
    {
        var mapperCfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<UserDTO, User>();
        });
        return mapperCfg;
    }
}