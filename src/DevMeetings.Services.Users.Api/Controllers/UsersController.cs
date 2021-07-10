using System.Threading.Tasks;
using DevMeetings.Services.Users.Api.Application.InputModels;
using DevMeetings.Services.Users.Api.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevMeetings.Services.Users.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInputModel userInputModel) {
            var id = await _userService.Add(userInputModel);

            return Created($"api/users/{id}", userInputModel);
        }
    }
}