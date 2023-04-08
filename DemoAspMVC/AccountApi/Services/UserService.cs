using AccountApi.Models.DTO;
using AccountApi.Repository;

namespace AccountApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDTO> AuthenticateUser(string email, string password)
    {
        var user = await _repository.GetUserByLogin(email, password);
        return user;
    }
}