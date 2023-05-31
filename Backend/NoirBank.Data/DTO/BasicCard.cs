using System;
using NoirBank.Data.Entities;

namespace NoirBank.Data.DTO
{
    public class BasicCard
    {
        public string HiddenNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Type { get; set; }
        public string Cover { get; set; }

        public BasicCard(Card card, string formattedShadowNumber, string cardType)
        {
            HiddenNumber = formattedShadowNumber;
            ExpirationMonth = card.ExpirationDate.ToString("MM");
            ExpirationYear = card.ExpirationDate.ToString("yy");
            Type = cardType ?? card.CardType.Type;
            Cover = card.Cover;
        }
    }
}

