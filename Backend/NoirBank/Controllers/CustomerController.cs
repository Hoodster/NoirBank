using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Data.Exceptions;
using System.Net;
using System.Threading.Tasks;
using NoirBank.Repositories;
using NoirBank.Data.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace NoirBank.Controllers
{
    [Route("api/customer")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public CustomerController(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
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
        public async Task<IActionResult> Register([FromBody] AccountDTO account)
        {
            try
            {
                await _userRepository.CreateAccountAsync(account, Data.Enums.ApplicationRoles.Customer);
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

        /// <summary>
        /// Get customer's billing history
        /// </summary>
        /// <response code="200">
        /// Billing
        ///
        ///     {
        ///        "status": 200
        ///        "data": [
        ///             {
        ///                 "AccountName": "Sample Bank Account Name",
        ///                 "OperationDate": "01/01/2000 12:12",
        ///                 "Title": "Sample operation title",
        ///                 "TransactionType": "Income | Outcome"
        ///                 "OperationType": "Transfer | Deposit | CardTransaction",
        ///                 "Amount": "100.50"
        ///             }
        ///        ]
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
        [HttpGet("billing")]
        public async Task<IActionResult> GetCustomerBillingHistory()
        {
            try
            {
                var result = await _accountRepository.GetBillingHistoryAsync();
                var content = new HTTPResponse(HttpStatusCode.OK, result);
                return new OkObjectResult(content);
            } catch (Exception e)
            {
                var content = new HTTPResponse(HttpStatusCode.OK, "account_unauthorized");
                return new OkObjectResult(content);
            }
        }

        [HttpGet("address")]
        public async Task<IActionResult> GetCustomerAddress()
        {
            try
            {
                var result = await _userRepository.GetAccountAddressAsync();
                var content = new HTTPResponse(HttpStatusCode.OK, result);
                return new OkObjectResult(content);
            } catch (Exception e)
            {
                var content = new HTTPResponse(HttpStatusCode.OK, "account_unauthorized");
                return new OkObjectResult(content);
            }
        }
    }
}

