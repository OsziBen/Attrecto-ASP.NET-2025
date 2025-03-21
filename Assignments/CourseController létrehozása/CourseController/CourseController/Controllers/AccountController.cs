using CourseController.Dtos;
using CourseController.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginDto loginDto)
        {
            var user = await _accountService.LoginAsync(loginDto);

            if (user == null)
            {
                return Unauthorized();
            }

            return _tokenService.CreateToken(user);
        }
    }
}
