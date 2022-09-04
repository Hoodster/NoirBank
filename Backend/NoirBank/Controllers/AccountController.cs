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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task AddAccount([FromBody] BankAccountDTO accountDTO)
        {
            await _accountRepository.CreateAccount(accountDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomerAccounts()
        {
            var result = await _accountRepository.GetAllAccounts();
            var content = new HTTPResponse(HttpStatusCode.OK, result);
            return new OkObjectResult(content);
        }
    }
}

