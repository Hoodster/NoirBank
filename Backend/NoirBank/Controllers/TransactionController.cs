using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Repositories;

namespace NoirBank.Controllers
{
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public TransactionController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GenerateTransactionPdf([FromQuery] string transactionID)
        {
            byte[] pdf = await _accountRepository.GenerateOperationPDF(transactionID);
            return File(pdf, "application/pdf");
        }
    }
}

