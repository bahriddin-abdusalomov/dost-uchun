using DemoProject.Dtos;
using DemoProject.Entities;

namespace DemoProject.Services.Contracts
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserDto userDto);
        Task<IList<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(long id);
        Task<bool> UpdateUserAsync(UserDto userDto, long id);
        Task<bool> DeleteUserAsync(long id);

    }
}
