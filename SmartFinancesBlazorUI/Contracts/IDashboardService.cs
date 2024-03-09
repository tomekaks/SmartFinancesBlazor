﻿using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IDashboardService
    {
        Task<DashboardVM> LoadDashboardVM();
        Task<List<AccountVM>> GetAllAccountsAsync();
        Task<bool> AddFundsAsync(AddFundsVM addFundsVM);
        Task ChangeAccountAsync(string accountNumber);
        Task<bool> RequestNewAccountAsync(NewAccountVM newAccountVM);
        Task<bool> RequestNewAccountAsync(int accountType);
        Task<WithdrawVM> LoadWithdrawVM();
        Task<bool> WithdrawFromSavingsAccountAsync(WithdrawVM withdrawVM);
    }
}
