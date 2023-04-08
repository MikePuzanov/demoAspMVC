using AutoMapper;

using Microsoft.EntityFrameworkCore;
using AccountApi.DbContext;
using AccountApi.Models;
using AccountApi.Models.DTO;

namespace AccountApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public UserRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserDTO>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> CreateOrUpdateUser(UserDTO productDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDTO> GetUserByLogin(string mail, string password)
    {
        var user = await _context.Users.Select(x => x).Where(x => x.Email == mail && x.Password == password).FirstOrDefaultAsync();
        var userDto = _mapper.Map<User, UserDTO>(user);
        return userDto;
    }
}