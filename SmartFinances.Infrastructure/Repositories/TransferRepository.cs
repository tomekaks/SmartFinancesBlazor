using Microsoft.EntityFrameworkCore;
using SmartFinances.Application.Interfaces.Repositories;
using SmartFinances.Core.Data;
using SmartFinances.Infrastructure.DataBase;

namespace SmartFinances.Infrastructure.Repositories
{
    public class TransferRepository : GenericRepository<Transfer>, ITransferRepository
    {
        public TransferRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Transfer>> GetPaginatedTransfersAsync(string accountNumber, int pageNumber, int pageSize)
        {
            var transfers = await _db.Where(q => q.SenderAccountNumber == accountNumber || q.ReceiverAccountNumber == accountNumber)
                                    .OrderByDescending(q => q.SendTime)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            return transfers;
        }
    }
}
