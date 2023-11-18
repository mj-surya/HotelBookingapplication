using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        /// <summary>
        /// Register the user
        /// </summary>
        /// <param name="userRegisterDTO">Information of user</param>
        /// <returns>Display user details</returns>
        [HttpPost("register")]
        public ActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            string message = "";
            try
            {
                var user = _userService.Register(userRegisterDTO);
                if (user != null)
                {
                    _logger.LogInformation("User Registerd");
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {
                _logger.LogError("Could not register user");
            }
            return BadRequest(message);
        }
        /// <summary>
        /// Login the user
        /// </summary>
        /// <param name="userDTO">Login details of user</param>
        /// <returns>Display the message</returns>
        [HttpPost("login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                _logger.LogInformation("Login Successful");
                return Ok(result);
            }
            _logger.LogError("Login failed");
            return Unauthorized("Invalid username or password");
        }
    }
}
