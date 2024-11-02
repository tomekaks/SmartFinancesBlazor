using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface ITransfersService
    {
        Task<TransfersOverviewVM> GenerateTransfersOverviewVM(int pageNumber = 1);
        Task<TransactionalAccountVM> GetCurrentAccountAsync();

        Task<SavingsTransfersOverviewVM> GenerateSavingsTransfersOverviewVM(int pageNumber = 1);
        Task<SavingsAccountVM> GetSavingsAccountAsync();

        Task<bool> CreateTransferAsync(NewTransferVM transferVM);
        Task<bool> DepositOnSavingsAccountAsync(decimal amount);
        Task<bool> WithdrawFromSavingsAccountAsync(decimal amount);

        Task<bool> AddToContactsAsync(NewTransferVM transferVM);
    }
}
