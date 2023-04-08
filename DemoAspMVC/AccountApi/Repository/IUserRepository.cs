using AccountApi.Models;
using AccountApi.Models.DTO;

namespace AccountApi.Repository;

public interface IUserRepository
{
    Task<IEnumerable<UserDTO>> GetUsers();
    Task<UserDTO> GetUserById(long id);
    Task<UserDTO> CreateOrUpdateUser(UserDTO productDto);
    Task<bool> DeleteUser(long id);
    Task<UserDTO> GetUserByLogin(string mail, string password);
}