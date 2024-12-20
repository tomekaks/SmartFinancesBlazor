﻿using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Repositories
{
    public interface ITransferRepository : IGenericRepository<Transfer>
    {
       Task<int> GetTransfersCountByAccountNumberAsync(string accountNumber);
       Task<List<Transfer>> GetPaginatedTransfersAsync(string accountNumber, int pageNumber, int pageSize);
    }
}
