using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;
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

        #region POST: SignIn

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
        /// <response code="400">
        /// Invalid credentials. Account has been locked.
        ///
        ///     {
        ///        "status": 400
        ///        "data": {
        ///             "type": "error"
        ///             "message": "account_locked"
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
                var email = await _userRepository.SignInAsync(credentials);
                var content = new HTTPResponse(HttpStatusCode.OK, new { Email = email});
                return new OkObjectResult(content);
            } catch(InvalidDataException e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e.Message);
                return new BadRequestObjectResult(content);
            }
            catch (LockedAccountException e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e.Message);
                return new BadRequestObjectResult(content);
            }
        }

        #endregion

        [HttpPost("token")]
        public async Task<IActionResult> ConfirmToken([FromBody] TwoFactorTokenDTO data)
        {
            try
            {
                var accessToken = await _userRepository.SignInTwoFactorAsync(data.Email, data.Token);
                var content = new HTTPResponse(HttpStatusCode.OK, accessToken);
                return new OkObjectResult(content);
            } catch (Exception)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, "invalid_token");
                return new BadRequestObjectResult(content);
            }
        }

        #region GET: Profile

        /// <summary>
        /// Gets basic user profile info
        /// </summary>
        /// <response code="200">
        /// User profile
        ///
        ///     {
        ///        "status": 200
        ///        "data": {
        ///             "FirstName": "Joe",
        ///             "LastName": "Doe",
        ///             "Email": "Joe.Doe@example.com",
        ///             "Login": "1111111"
        ///        }
        ///     }
        ///
        /// </response>
        /// <response code="401">
        /// Unauthorized. Token missing or expired.
        ///
        ///     {
        ///        "status": 401
        ///        "data": {
        ///             "type": "error"
        ///             "message": "account_unauthorized"
        ///        }
        ///     }
        /// </response>
        [HttpGet("profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var profile = await _userRepository.GetProfileAsync();
                var content = new HTTPResponse(HttpStatusCode.OK, profile);
                return new OkObjectResult(content);
            }
            catch (Exception)
            {
                var content = new HTTPResponse(HttpStatusCode.Unauthorized, "account_unauthorized");
                return new UnauthorizedObjectResult(content);
            }
        }

        #endregion

        #region GET: SessionLogs

        /// <summary>
        /// Gets basic user login history
        /// </summary>
        /// <response code="200">
        /// Session logs
        ///
        ///     {
        ///         "status": 200,
        ///         "data": [
        ///             {
        ///                 "SessionID": "abc123-12312-12321-12312",
        ///                 "SessionDate": "01/01/2000 12:12:12",
        ///                 "IsSuccessful": "Succeed | Failed"
        ///             }
        ///         ]
        ///     }
        ///
        /// </response>
        /// <response code="401">
        /// Unauthorized. Token missing or expired.
        ///
        ///     {
        ///        "status": 401
        ///        "data": {
        ///             "type": "error"
        ///             "message": "account_unauthorized"
        ///        }
        ///     }
        /// </response>
        [HttpGet("sessionlogs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
                var content = new HTTPResponse(HttpStatusCode.Unauthorized, "account_unauthorized");
                return new UnauthorizedObjectResult(content);
            }
        }

        #endregion
    }
}