using System;
using System.Threading.Tasks;
using NoirBank.Data.DTO;

namespace NoirBank.Repositories
{
    public interface ITransferRepository
    {
        Task MakeTransferAsync(TransferDTO transfer);
    }
}

