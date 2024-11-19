using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class TransfersService : BaseHttpService, ITransfersService
    {
        private readonly IMapper _mapper;
        private readonly IAccountsService _accountsService;
        public TransfersService(IClient client, IMapper mapper, ILocalStorageService localStorage, 
            IAccountsService accountsService)
            : base(client, localStorage)
        {
            _mapper = mapper;
            _accountsService = accountsService;
        }

        public async Task<bool> CreateTransferAsync(NewTransferVM transferVM)
        {
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);
            transferDto.SendTime = DateTime.UtcNow;
            transferDto.SenderAccountNumber = await GetCurrentAccountNumberAsync();

            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

        public async Task<TransfersOverviewVM> GenerateTransfersOverviewVM(int pageNumber = 1)
        {
            var currentAccount = await _accountsService.GetCurrentAccountAsync();

            var transfersVM = await GetPaginatedTransfersAsync(currentAccount.Number, pageNumber);

            var orderedTransfers = transfersVM.Items.OrderByDescending(q => q.SendTime).ToList();

            foreach (var transfer in orderedTransfers)
            {
                transfer.CurrentAccountNumber = currentAccount.Number;
            }

            var groupedTransfers = orderedTransfers.GroupBy(q => q.SendTime).ToList();

            return new TransfersOverviewVM()
            {
                GroupedTransfers = groupedTransfers,
                TotalPages = transfersVM.TotalPages,
                CurrentPage= transfersVM.PageNumber
            };
        }

        public async Task<bool> DepositOnSavingsAccountAsync(decimal amount)
        {
            var transferDto = await GetSavingsAccountTransferDto(amount, Constants.DEPOSIT);
            await _client.TransfersDepositToSavingsAccountAsync(transferDto);
            return true;
        }

        public async Task<bool> WithdrawFromSavingsAccountAsync(decimal amount)
        {
            var transferDto = await GetSavingsAccountTransferDto(amount, Constants.WITHDRAW);
            await _client.TransfersWithdrawFromSavingsAccountAsync(transferDto);
            return true;
        }

        private async Task<PaginatedList<TransferVM>> GetPaginatedTransfersAsync(string accountNumber, int pageNumber = 1, int pageSize = 10)
        {
            var transfersDto = await _client.TransfersGetWithPaginationAsync(accountNumber, pageNumber, pageSize);

            if (transfersDto == null || transfersDto.Items.Count < 1)
            {
                return new PaginatedList<TransferVM>(new List<TransferVM>(), 1, 10, 1, 0);
            }

            var transfersVM = _mapper.Map<List<TransferVM>>(transfersDto.Items);

            var paginaterTransfersVM = new PaginatedList<TransferVM>(
                transfersVM, transfersDto.PageNumber, transfersDto.PageSize, transfersDto.TotalPages, transfersDto.TotalCount);

            return paginaterTransfersVM;
        }

        private async Task<SavingsAccountTransferDto> GetSavingsAccountTransferDto(decimal amount, string operation)
        {
            var currentAccount = await _accountsService.GetCurrentAccountAsync();
            var savingsAccount = await _accountsService.GetUsersSavingsAccountAsync();

            return new SavingsAccountTransferDto()
            {
                Amount = amount,
                TransactionalAccountName = currentAccount.Name,
                TransactionalAccountNumber = currentAccount.Number,
                SavingsAccountName = savingsAccount.Name,
                SavingsAccountNumber = savingsAccount.Number,
                SendTime = DateTime.UtcNow,
                Title = operation
            };
        }

    } 
}
