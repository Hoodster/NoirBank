using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoirBank.Data.DTO;
using NoirBank.Utils;

namespace NoirBank.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IAuthenticationService _authService;

        public CardRepository(DatabaseContext databaseContext, IAuthenticationService authService)
        {
            _databaseContext = databaseContext;
            _authService = authService;
        }

        public Task AddCard()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BasicCard>> GetAllCustomerCards()
        {
            var currentUser = await _authService.GetCurrentUserAsync();
            var cards = _databaseContext
                .BankAccounts
                .Where(bankAccount => bankAccount.CustomerID == currentUser.CustomerID)
                .Include(x => x.Cards)
                .Select(x => x.Cards)
                .ToList();
            var result = new List<BasicCard>();
            foreach(var innerCards in cards)
            {
                foreach (var card in innerCards) {
                    var shadowNumber = BankNumbersHelper.ShadowCardNumber(card.CardNumber);
                    result.Add(new BasicCard
                    {
                        HiddenNumber = BankNumbersHelper.FormatCardNumber(shadowNumber),
                        ExpirationMonth = card.ExpirationDate.Month.ToString(),
                        ExpirationDay = card.ExpirationDate.Day.ToString(),
                        Type = card.CardType == Data.Enums.CardTypes.Credit ? "Credit" : "Debit",
                        Cover = "card2"
                    });
                 }
            }

            return result;
        }
    }
}

