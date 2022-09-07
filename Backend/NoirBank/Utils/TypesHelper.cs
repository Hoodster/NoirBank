using System;
using NoirBank.Data.Enums;

namespace NoirBank.Utils
{
    public static class TypesHelper
    {
        public static Guid MapAccountTypes(string accountType)
        {
            switch(accountType)
            {
                case AccountTypesOptions.STANDARD:
                    return AccountTypesIDs.STANDARD;
                case AccountTypesOptions.BUSINESS:
                    return AccountTypesIDs.BUSINESS;
                case AccountTypesOptions.SAVING:
                    return AccountTypesIDs.SAVING;
                case AccountTypesOptions.INVESTMENT:
                    return AccountTypesIDs.INVESTMENT;
                default:
                    throw new Exception();
            }
        }

        public static Guid MapCardTypes(string cardType)
        {
            switch(cardType)
            {
                case CardTypesOptions.DEBIT:
                    return CardTypesIDs.DEBIT;
                case CardTypesOptions.CREDIT:
                    return CardTypesIDs.CREDIT;
                default:
                    throw new Exception();
            }
        }
    }
}

