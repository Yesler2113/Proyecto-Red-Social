using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Red_Social_Proyecto.Dtos;
using Red_Social_Proyecto.Dtos.Task;
using Red_Social_Proyecto.Dtos.ValidationsDto;
using Red_Social_Proyecto.Services.Interfaces;

namespace Red_Social_Proyecto.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public LoginController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        [HttpPost]

        public async Task<ActionResult<ResponseDto<UsersDto>>> Create([FromBody] UsersCreateDto model)
        {
            var response = await _usersService.CreateUserAsync(model);

            return StatusCode(response.StatusCode, response);
        }


    }
}
