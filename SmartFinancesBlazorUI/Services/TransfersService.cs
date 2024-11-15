using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Models.Dashboard;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Pages.Transfers;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class TransfersService : BaseHttpService, ITransfersService
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly IContactsService _contactsService;
        public TransfersService(IClient client, IMapper mapper, ILocalStorageService localStorage, 
            IAccountService accountService, IContactsService contactsService)
            : base(client, localStorage)
        {
            _mapper = mapper;
            _accountService = accountService;
            _contactsService = contactsService;
        }

        public async Task<bool> CreateTransferAsync(NewTransferVM transferVM)
        {
            var receiverAccount = await _accountService.CheckIfTransactionalAccountExistsAsync(transferVM.ReceiverAccountNumber);
            if (receiverAccount == null)
            {
                return false;
            }

            transferVM.SendTime = DateTime.UtcNow;
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);
            transferDto.SenderAccountNumber = await GetCurrentAccountNumberAsync();

            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

        public async Task<TransactionalAccountVM> GetCurrentAccountAsync()
        {
            var accountNumber = await GetCurrentAccountNumberAsync();
            var currentAccount = await _accountService.GetTransactionalAccountByNumberAsync(accountNumber);

            return currentAccount;
        }

        public async Task<TransfersOverviewVM> GenerateTransfersOverviewVM(int pageNumber = 1)
        {
            var currentAccount = await GetCurrentAccountAsync();

            var transfersVM = await GetPaginatedTransfersAsync(currentAccount.Number, pageNumber);

            var orderedTransfers = transfersVM.Items.OrderByDescending(q => q.SendTime).ToList();

            foreach (var transfer in orderedTransfers)
            {
                transfer.CurrentAccountNumber = currentAccount.Number;
            }

            var groupedTransfers = orderedTransfers.GroupBy(q => q.SendTime).ToList();

            return new TransfersOverviewVM()
            {
                CurrentAccount = currentAccount,
                GroupedTransfers = groupedTransfers,
                TotalPages = transfersVM.TotalPages,
                CurrentPage= transfersVM.PageNumber
            };
        }

        public async Task<SavingsAccountVM> GetSavingsAccountAsync()
        {
            var savingsAccount = await _accountService.GetSavingsAccountAsync();

            return savingsAccount;
        }

        public async Task<SavingsTransfersOverviewVM> GenerateSavingsTransfersOverviewVM(int pageNumber = 1)
        {
            var savingsAccount = await GetSavingsAccountAsync();

            var transfersVM = await GetPaginatedTransfersAsync(savingsAccount.Number, pageNumber);

            var orderedTransfers = transfersVM.Items.OrderByDescending(q => q.SendTime).ToList();

            foreach (var transfer in orderedTransfers)
            {
                transfer.CurrentAccountNumber = savingsAccount.Number;
            }

            var groupedTransfers = orderedTransfers.GroupBy(q => q.SendTime).ToList();

            return new SavingsTransfersOverviewVM()
            {
                SavingsAccount = savingsAccount,
                GroupedTransfers = groupedTransfers,
                TotalPages = transfersVM.TotalPages,
                CurrentPage = transfersVM.PageNumber
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

        public async Task<bool> AddToContactsAsync(NewTransferVM transferVM)
        {
            var newContact = new NewContactVM()
            {
                Name = transferVM.ReceiverName,
                AccountNumber = transferVM.ReceiverAccountNumber
            };

            return await _contactsService.CreateContactAsync(newContact);
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
            var currentAccount = await GetCurrentAccountAsync();
            var savingsAccount = await GetSavingsAccountAsync();

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
