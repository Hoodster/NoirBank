using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Data.Utils;
using NoirBank.Repositories;

namespace NoirBank.Controllers
{
    [Route("api/bankaccount")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] BankAccountDTO accountDTO)
        {
            var result = await _accountRepository.CreateAccount(accountDTO);
            var content = new HTTPResponse(HttpStatusCode.OK, result);
            return new OkObjectResult(content);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerAccounts()
        {
            var result = await _accountRepository.GetAllAccounts();
            var content = new HTTPResponse(HttpStatusCode.OK, result);
            return new OkObjectResult(content);
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> DepositMoney([FromBody] DepositDTO deposit)
        {
            await _accountRepository.DepositToAccountAsync(deposit);
            var content = new HTTPResponse(HttpStatusCode.OK, "ok");
            return new OkObjectResult(content);
        }

        [HttpGet("braintree")]
        [AllowAnonymous]
        public IActionResult TestBraintree()
        {
            _accountRepository.TestTransaction();
            return new OkResult();
        }
    }
}

