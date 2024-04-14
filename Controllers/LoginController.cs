using LearningPlayground.Helpers;
using LearningPlayground.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;

        public LoginController(JwtHelper jwtHelper) { 
            _jwtHelper = jwtHelper;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ValidateUser(login))
            {
                var token = _jwtHelper.GenerateToken(login.UserID);
                return Ok(new { token });
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ValidateUser(LoginViewModel login)
        {
            // TODO: 驗證身分
            return true;
        }
    }
}
