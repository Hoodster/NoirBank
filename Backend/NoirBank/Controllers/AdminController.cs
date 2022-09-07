using System;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Data.Exceptions;
using NoirBank.Repositories;
using NoirBank.Data.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace NoirBank.Controllers
{
    [Route("api/admin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public AdminController(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
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
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] BaseAccountDTO account)
        {
            try
            {
                var accountMap = new AccountDTO
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Email = account.Email,
                    Password = account.Password
                };

                await _userRepository.CreateAccountAsync(accountMap, Data.Enums.ApplicationRoles.Admin);
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
            catch (Exception e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e);
                return new BadRequestObjectResult(content);
            }
        }

        [HttpGet("accounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var accounts = await _userRepository.GetAllAccounts();
                var content = new HTTPResponse(HttpStatusCode.OK, accounts);
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
            catch (Exception e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e);
                return new BadRequestObjectResult(content);
            }
        }

        [HttpPost("bankaccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult GetBankAccounts([FromBody] string customerId)
        {
            try
            {
                var accounts = _accountRepository.GetAllAccountsByCustomerID(customerId);
                var content = new HTTPResponse(HttpStatusCode.OK, accounts);
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
            catch (Exception e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e);
                return new BadRequestObjectResult(content);
            }
        }

        [HttpPost("switchlock/account")]
        public async Task<IActionResult> SwitchAccountLock([FromBody] string userId)
        {
            try
            {
                await _userRepository.SwitchAccountLock(userId);
                var content = new HTTPResponse(HttpStatusCode.OK, "ok");
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
            catch (Exception e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e);
                return new BadRequestObjectResult(content);
            }
        }

        [HttpPost("switchlock/bankaccount")]
        public async Task<IActionResult> SwitchBankAccountLock([FromBody] string accountNumber)
        {
            try
            {
                var accountNumberCondensed = accountNumber.Replace(" ", "");
                await _accountRepository.SwitchAccountLock(accountNumberCondensed);
                var content = new HTTPResponse(HttpStatusCode.OK, "ok");
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
            catch (Exception e)
            {
                var content = new HTTPResponse(HttpStatusCode.BadRequest, e);
                return new BadRequestObjectResult(content);
            }
        }

    }
}

