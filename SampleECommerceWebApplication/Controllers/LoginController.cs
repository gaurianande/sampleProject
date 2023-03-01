using Ecommerce.Domain.Models;
using ECommerce.Application.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SampleECommerceWebApplication.Controllers
{
    [ApiController]
    [Route("controller")]
    public class LoginController : ControllerBase
    {
        
        private IRepositoryWrapper _userRepository;
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public LoginController(IRepositoryWrapper userRepository)
        {
            _userRepository= userRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Credentials credentials)
        {
            var user = await _userRepository.User.FindByCondition(x => x.Username == credentials.Username);
            if(user!=null && user.Password==credentials.Password )
               return Ok(user.Username);
            return Unauthorized();
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUser([FromBody]User user)
        {
            var user1 = await _userRepository.User.FindByCondition(x => x.Username == user.Username);
            if (user1 != null)
                return BadRequest("User already exists");
            await _userRepository.User.Create(user);
            return Ok(user.Role.ToString());
        }
    }
}
