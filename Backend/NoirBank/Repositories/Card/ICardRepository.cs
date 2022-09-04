using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public interface ICardRepository
    {
        Task AddCardAsync(CardDTO card);
        Task<IList<BasicCard>> GetAllCustomerCards();
    }
}

