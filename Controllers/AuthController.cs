using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Myo.ConfigurationModels;
using Myo.DAL;
using Myo.Helpers;
using Myo.Models;
using Myo.Wrappers;

namespace Myo.Controllers
{

    [Route("api/v1/[controller]")]
    [Authorize]
    public class AuthController : Controller
    {

        private IUserRepository userRepository;
        private readonly IOptions<AuthOptions> authOptions;
        public AuthController(IUserRepository userRepository, IOptions<AuthOptions> authOptions)
        {
            this.userRepository = userRepository;
            this.authOptions = authOptions;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public IActionResult Login([FromBody] User user)
        {
            // Checking mandatory fields
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
                return Json(new SimpleResponser { Success = false, Message = "Username and password are mandatory."});

            // Checking the user
            user.Password = CryptoHelper.GenerateSHA512String(user.Password);
            User fullUser = userRepository.GetUserByCredentials(user.Username, user.Password);

            if (fullUser == null)
                return Json(new SimpleResponser { Success = false, Message = "The crediantials are incorrect."});

            // Generating the token
            string token = JWTHelper.CreateToken(fullUser.IdUser, authOptions.Value.Secret);

            return Json(new ComplexResponser<string> { Success = true, Message = "User loged correctly.", Result = token});
        }
    }
}