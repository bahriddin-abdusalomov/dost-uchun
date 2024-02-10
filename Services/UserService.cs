using DemoProject.Dtos;
using DemoProject.Entities;
using DemoProject.Interfaces;
using DemoProject.Services.Contracts;

namespace DemoProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUserAsync(UserDto userDto)
        {
            User user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            };

            int result = await _userRepository.CreateAsync(user);
            return result > 0;
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return false;
            }

           int result = await _userRepository.DeleteAsync(user);
           return result > 0;
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<User> GetUserAsync(long id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return new User();
            }
            return user;
        }

        public async Task<bool> UpdateUserAsync(UserDto userDto, long id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return false;
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.Password = userDto.Password;

            int result = await _userRepository.UpdateAsync(user);
            return result > 0;
        }
    }
}
