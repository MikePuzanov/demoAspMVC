using AccountApi.Models.DTO;

namespace AccountApi.Services;

public interface IUserService
{
    Task<UserDTO> AuthenticateUser(string email, string password);
}