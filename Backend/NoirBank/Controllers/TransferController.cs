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
    [Route("api/transfer")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
    public class TransferController : Controller
    {
        private readonly ITransferRepository _transferRepository;

        public TransferController(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        [HttpPost]
        public async Task<IActionResult> MakeTransfer([FromBody] TransferDTO transfer)
        {
            await _transferRepository.MakeTransferAsync(transfer);
            var content = new HTTPResponse(HttpStatusCode.OK, "ok");
            return new OkObjectResult(content);
        }
    }
}

