using System;
namespace NoirBank.Data.DTO
{
    public class SessionLogDTO
    {
        public Guid SessionID { get; set; }
        public string SessionDate { get; set; }
        public string IsSuccessful { get; set; }

        public SessionLogDTO()
        {
        }
    }
}

