using GroupEventAPI.Models;
using GroupEventAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace GroupEventAPI.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController:ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.Register(newUser);

            return Created("Account/Register", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> login([FromBody] LoginRequestModel loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.Login(loginRequest);

            if (!result.Success)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult test()
        {
            return Ok(DateTime.UtcNow);
        }
    }
}
