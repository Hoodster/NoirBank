using System;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Data.Exceptions;
using NoirBank.Repositories;
using NoirBank.Data.Utils;

namespace NoirBank.Controllers
{
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AdminController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Creates new administrator account
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
        /// Invalid data. Possibly missing data or bad format.
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
        /// Unhandled exception
        ///
        ///     {
        ///        "status": 400
        ///        "data": {
        ///             "type": "error"
        ///             "message": "unhandled_exception"
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
        public async Task<IActionResult> Register([FromBody] BaseAccountDTO account)
        {
            try
            {
                await _userRepository.CreateAccountAsync((AccountDTO)account, Data.Enums.ApplicationRoles.Admin);
                var content = new HTTPResponse(HttpStatusCode.OK, "account_created", false);
                return new OkObjectResult(content);
            }
            catch (RecordExistsException e)
            {
                var content = new HTTPResponse(HttpStatusCode.Conflict, e.Message);
                return new ConflictObjectResult(content);
            }
            catch (InvalidDataException e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e.Message);
                return new BadRequestObjectResult(content);
            }
            catch (Exception)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, "unhandled_exception");
                return new BadRequestObjectResult(content);
            }
        }
    }
}

