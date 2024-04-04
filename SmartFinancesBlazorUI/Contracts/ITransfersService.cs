using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface ITransfersService
    {
        Task<TransfersOverviewVM> GenerateTransfersOverviewVM();
        Task<bool> CreateTransferAsync(NewTransferVM transferVM);
        Task DepositOnSavingsAccountAsync(SavingsAccountTransferDto transferDto);
        Task WithdrawFromSavingsAccountAsync(SavingsAccountTransferDto transferDto);
    }
}
