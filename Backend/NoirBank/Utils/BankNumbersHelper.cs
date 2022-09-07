using System;
using System.Numerics;

namespace NoirBank.Utils
{
    public class BankNumbersHelper
    {
        private const int _bankCode = 2137;
        private const int _bankDepartment = 2022;
        private const int _pNumberCode = 25;
        private const int _lNumberCode = 21;

        private readonly Random _random;

        public BankNumbersHelper()
        {
            _random = new Random();
        }

        public static string GenerateBankAccountNumber()
        {
            var accountNumberBase = $"{_bankDepartment}{GenerateDigitsPart()}{GenerateDigitsPart()}{GenerateDigitsPart()}{GenerateDigitsPart()}";
            return $"{GenerateBankAccountControlNumber(accountNumberBase)}{_bankCode}{accountNumberBase}";
        }

        public static string SplitBankAccountNumber(string bankAccountNumber)
        {
            return $"{bankAccountNumber.Substring(0, 2)} " + // control sum
                $"{bankAccountNumber.Substring(2, 4)} " +    // bank code
                $"{bankAccountNumber.Substring(6, 4)} " +    // department
                $"{bankAccountNumber.Substring(10, 4)} " +    // acc number 1
                $"{bankAccountNumber.Substring(14, 4)} " +  // acc number 2
                $"{bankAccountNumber.Substring(18, 4)} " +  // acc number 3
                $"{bankAccountNumber.Substring(22)}";
        }

        public static string GenerateBankCardNumber()
        {
            var cardNumberBase = $"1{_bankCode}{GenerateDigitsPart()}{GenerateDigitsPart()}{GenerateDigitsPart().Substring(1, 2)}";
            return $"{cardNumberBase}{GenerateBankCardControlNumber(cardNumberBase)}";
        }

        public static string ShadowCardNumber(string cardNumber)
        {
            return $"{cardNumber.Substring(0, 4)}********{cardNumber.Substring(12)}";
        }

        public static string FormatCardNumber(string cardNumber)
        {
            return $"{cardNumber.Substring(0, 4)} {cardNumber.Substring(4, 4)} {cardNumber.Substring(8, 4)} {cardNumber.Substring(12)}";
        }

        private static string GenerateDigitsPart()
        {
            return new Random().Next(1000, 9999).ToString();
        }

        private static string GenerateBankCardControlNumber(string cardNumber)
        {
            var sum = 0;

            for (int i = 0; i < cardNumber.Length; i++)
            {
                var fixedPosition = i + 1;
                var digit = int.Parse(cardNumber[i].ToString());
                if (fixedPosition % 2 == 0)
                {
                    sum += digit;
                } else
                {
                    sum += digit * 2;
                }
            }
            return (sum % 10).ToString();
        }

        private static string GenerateBankAccountControlNumber(string accountNumber)
        {
            var controlAccountNumber = BigInteger.Parse($"{accountNumber}{_pNumberCode}{_lNumberCode}{_bankCode}");
            var controlNumber = controlAccountNumber % 97;
            return controlNumber > 9 ? controlNumber.ToString() : $"{controlNumber}0";
        }

    }
}

