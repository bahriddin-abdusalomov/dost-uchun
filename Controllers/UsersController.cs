using DemoProject.Dtos;
using DemoProject.Services.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserDto userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);
            if (result)
            {
                return Ok("Muvafaqiyatli qoshildi");
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            var user = await _userService.GetUserAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(long id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                return Ok("Muvafaqiyatli o'chirildi");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(UserDto userDto, long id)
        {
            var result = await _userService.UpdateUserAsync(userDto, id);
            if(result)
            {
                return Ok("User yangilandi");
            }
            return BadRequest();
        }
    }
}
