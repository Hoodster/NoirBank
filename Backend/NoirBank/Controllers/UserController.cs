using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Data.Exceptions;
using NoirBank.Data.Utils;
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

        /// <summary>
        /// First step account login
        /// </summary>
        /// <param name="credentials">Account number and password</param>
        /// <response code="200">
        /// User successfully signed in by credentials
        ///
        ///     {
        ///        "status": 200
        ///        "data": {
        ///             "token": "Bearer {token}"
        ///             "expiresIn": 1231234
        ///        }
        ///     }
        ///
        /// </response>
        /// <response code="400">
        /// Invalid credentials. For example wrong type of information or missing data.
        ///
        ///     {
        ///        "status": 400
        ///        "data": {
        ///             "type": "error"
        ///             "message": "invalid_data"
        ///        }
        ///     }
        ///
        /// </response>
        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] Credentials credentials)
        {
            try
            {
                var result = await _userRepository.SignInAsync(credentials);
                var content = new HTTPResponse(HttpStatusCode.OK, result);
                return new OkObjectResult(content);
            } catch(InvalidDataException e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e.Message);
                return new BadRequestObjectResult(content);
            }
        }

        [HttpGet("profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetProfile()
        {
            var profile = await _userRepository.GetProfileAsync();
            var content = new HTTPResponse(HttpStatusCode.OK, profile);
            return new OkObjectResult(content);
        }

        [HttpGet("sessionlogs")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetSessionLogs()
        {
            try
            {
                var sessionLogs = await _userRepository.GetUserSessionLogsAsync();
                var content = new HTTPResponse(HttpStatusCode.OK, sessionLogs);
                return new OkObjectResult(content);
            } catch (Exception e)
            {
                var t = e;
           }
            return Ok();
        }
    }
}