using System;
using System.ComponentModel.DataAnnotations;

namespace NoirBank.Data.Enums
{
    public static class AccountTypesOptions
    {
        public const string STANDARD = "Standard";
        public const string SAVING = "Saving";
        public const string BUSINESS = "Business";
        public const string INVESTMENT = "Investment";
    }

    public static class AccountTypesIDs
    {
        public static readonly Guid STANDARD = new Guid("79c2ca91-3af7-4615-9bc9-2e7b5a2b4abd");
        public static readonly Guid SAVING = new Guid("37dee5ac-da17-49f4-a619-4c4ac12846d5");
        public static readonly Guid BUSINESS = new Guid("2a272075-8fcc-4f5c-a7f8-0517d9c48bb7");
        public static readonly Guid INVESTMENT = new Guid("fbed716d-f4ab-4235-bce3-fb08fa9d5baf");
    }          

    public class AccountType
    {
        [Key]
        public Guid AccountTypeID { get; set; }
        public string Type { get; set; }
    }
}

