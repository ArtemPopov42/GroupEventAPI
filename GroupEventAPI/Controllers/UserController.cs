using GroupEventAPI.Models.Requests;
using GroupEventAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GroupEventAPI.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent(CreateEventRequestModel createEventRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.CreateEvent(User.FindFirstValue(ClaimTypes.NameIdentifier), createEventRequest);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(await _userService.GetEvents(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}
