using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Makes transfer operation
        /// </summary>
        /// <param name="transfer">Transfer data</param>
        /// <response code="200">
        /// User successfully signed in by credentials
        ///
        ///     {
        ///        "status": 200
        ///        "data": "ok"
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MakeTransfer([FromBody] TransferDTO transfer)
        {
            await _transferRepository.MakeTransferAsync(transfer);
            var content = new HTTPResponse(HttpStatusCode.OK, "ok");
            return new OkObjectResult(content);
        }
    }
}

