using GroupEventAPI.Models;
using GroupEventAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Claims;

namespace GroupEventAPI.Controllers
{
    [ApiController]
    [Route("api/Account")]
    public class AccountController:ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        [Consumes("application/json")]
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
        [Consumes("application/json")]
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

        public class testRequest
        {
            public string name { get; set; }
            public string text { get; set; }
        }

        //[Authorize]
        [HttpPost("test")]
        public IActionResult test([FromBody] testRequest request)
        {
            Console.WriteLine("test");
            return Ok(new 
            {
                text = request.text,
            });
        }
    }
}
