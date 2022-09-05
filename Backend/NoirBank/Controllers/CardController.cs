using System;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoirBank.Data.DTO;
using NoirBank.Data.Utils;
using NoirBank.Repositories;

namespace NoirBank.Controllers
{
    [Route("api/card")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CardController : Controller
    {
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCustomerCards()
        {
           var result = await _cardRepository.GetAllCustomerCards();
           var content = new HTTPResponse(HttpStatusCode.OK, result);
           return new OkObjectResult(content);
        }

        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] CardDTO card)
        {
            var result = await _cardRepository.AddCardAsync(card);
            var content = new HTTPResponse(HttpStatusCode.OK, result);
            return new OkObjectResult(content);
        }
    }
}

