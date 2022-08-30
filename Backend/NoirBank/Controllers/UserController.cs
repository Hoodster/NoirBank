using System;
using System.Net;
using System.Threading.Tasks;
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
        /// Creates new user account
        /// </summary>
        /// <param name="account">New account DTO</param>
        /// <response code="200">
        /// Account has been created
        ///
        ///     {
        ///        "status": 200
        ///        "data": {
        ///             "type": "response"
        ///             "message": "account_created"
        ///        }
        ///     }
        ///
        /// </response>
        /// <response code="400">
        /// Account already exists
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
        /// <response code="409">
        /// Account already exists
        ///
        ///     {
        ///        "status": 409
        ///        "data": {
        ///             "type": "error"
        ///             "message": "record_already_exist"
        ///        }
        ///     }
        ///
        /// </response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] NewAccount account)
        {
            try
            {
                await _userRepository.CreateAccount(account);
                var content = new HTTPResponse(HttpStatusCode.OK, "account_created", false);
                return new OkObjectResult(content);
            } catch (RecordExistsException e)
            {
                var content = new HTTPResponse(HttpStatusCode.Conflict, e.Message);
                return new ConflictObjectResult(content);
            } catch (InvalidDataException e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e.Message);
                return new BadRequestObjectResult(content);
            }
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
        ///             "type": "response"
        ///             "message": "valid_credentials"
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
                await _userRepository.CreateAccount(null);
                var content = new HTTPResponse(HttpStatusCode.OK, "valid_credentials", false);
                return new OkObjectResult(content);
            } catch(InvalidDataException e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e.Message);
                return new BadRequestObjectResult(content);
            }
        }
    }
}