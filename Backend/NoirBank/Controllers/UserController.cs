using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Repositories;

namespace NoirBank.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<OkResult> Register([FromBody] NewAccount account)
        {
            await _userRepository.CreateAccount(account);
            return Ok();
        }

        [HttpPost("signin")]
        public async Task Login([FromBody] Credentials credentials)
        {

        }
    }
}