using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoirBank.Data.DTO;
using NoirBank.Data.Entities;
using NoirBank.Data.Enums;
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

        public async Task AddCardAsync(CardDTO card)
        {
            var accountID = _databaseContext.BankAccounts
                .Select(account => new { account.AccountID, account.AccountNumber })
                .FirstOrDefault(account => account.AccountNumber.Equals(card.Account)).AccountID;

            var newCard = new Card
            {
                CardNumber = BankNumbersHelper.GenerateBankCardNumber(),
                Cover = card.Cover,
                CardType = Enum.Parse<CardTypes>(card.Type, true),
                ExpirationDate = new DateTime().AddYears(6),
                CVV = new Random().Next(100, 999),
                AccountID = accountID
            };
            await _databaseContext.AddAsync(newCard);
            await _databaseContext.SaveChangesAsync();
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

