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

        public async Task<BasicCard> AddCardAsync(CardDTO card)
        {
            var accountID = _databaseContext.BankAccounts
                .Select(account => new { account.AccountID, account.AccountNumber })
                .FirstOrDefault(account => account.AccountNumber.Equals(card.Account)).AccountID;

            var newCard = new Card
            {
                CardNumber = BankNumbersHelper.GenerateBankCardNumber(),
                Cover = card.Cover,
                CardTypeID = TypesHelper.MapCardTypes(card.Type),
                ExpirationDate = DateTime.UtcNow.AddYears(6),
                CVV = new Random().Next(100, 999),
                AccountID = accountID
            };
            var result = await _databaseContext.AddAsync(newCard);
            await _databaseContext.SaveChangesAsync();
            return PrepareBasicCardInfo(result.Entity, card.Type);
        }

        public async Task<IList<BasicCard>> GetAllCustomerCards()
        {
            var currentUser = await _authService.GetCurrentUserAsync();
            var cards = _databaseContext
                .BankAccounts
                .Where(bankAccount => bankAccount.CustomerID == currentUser.CustomerID)
                .Include(bankAccount => bankAccount.Cards)
                .SelectMany(bankAccount => bankAccount.Cards)
                .Include(card => card.CardType)
                .Select(card => PrepareBasicCardInfo(card, null))
                .ToList();

            return cards;
        }

        private static BasicCard PrepareBasicCardInfo(Card card, string cardType = null)
        {
            var shadowNumber = BankNumbersHelper.ShadowCardNumber(card.CardNumber);
            return new BasicCard
            {
                HiddenNumber = BankNumbersHelper.FormatCardNumber(shadowNumber),
                ExpirationMonth = card.ExpirationDate.ToString("MM"),
                ExpirationYear = card.ExpirationDate.ToString("yy"),
                Type = cardType != null ? cardType : card.CardType.Type,
                Cover = card.Cover
            };
        }
    }
}

