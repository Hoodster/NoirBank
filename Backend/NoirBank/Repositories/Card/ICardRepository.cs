using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public interface ICardRepository
    {
        Task AddCard();
        Task<IList<BasicCard>> GetAllCustomerCards();
    }
}

