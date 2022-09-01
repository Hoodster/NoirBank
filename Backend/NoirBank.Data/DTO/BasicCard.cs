using System;

namespace NoirBank.Data.DTO
{
    public class BasicCard
    {
        public string HiddenNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationDay { get; set; }
        public string Type { get; set; }
        public string Cover { get; set; }
    }
}

