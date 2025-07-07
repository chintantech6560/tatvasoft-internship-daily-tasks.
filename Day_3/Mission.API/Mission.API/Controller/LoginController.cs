using Microsoft.AspNetCore.Mvc;
using Mission.Entity.ViewModel;
using Mission.Entity.ViewModel.Login;
using Mission.Services.IService;

namespace Mission.Api.Controlle
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(iService userService) : ControllerBase
    {
        private readonly iService _userService = userService;

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(UserLoginRequestModel model) 
        {
            var response = await _userService.LogiUser(model);

            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
