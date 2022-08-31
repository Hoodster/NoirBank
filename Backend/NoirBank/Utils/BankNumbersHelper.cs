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
            return $"{GenerateControlNumber(accountNumberBase)}{_bankCode}{accountNumberBase}";
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

        private static string GenerateDigitsPart()
        {
            return new Random().Next(1000, 9999).ToString();
        }

        private static string GenerateControlNumber(string accountNumber)
        {
            var controlAccountNumber = BigInteger.Parse($"{accountNumber}{_pNumberCode}{_lNumberCode}{_bankCode}");
            var controlNumber = controlAccountNumber % 97;
            return controlNumber > 9 ? controlNumber.ToString() : $"{controlNumber}0";
        }

    }
}

