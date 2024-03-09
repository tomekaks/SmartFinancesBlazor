using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Transfers;
using SmartFinancesBlazorUI.Services.Base;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class TransfersService : BaseHttpService, ITransfersService
    {
        private readonly IMapper _mapper;
        public TransfersService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<bool> CreateTransferAsync(NewTransferVM transferVM)
        {
            transferVM.SendTime= DateTime.UtcNow;
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);
            transferDto.SenderAccountNumber = await GetCurrentAccountNumberAsync();

            await AddBearerToken();
            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

        public async Task<TransfersOverviewVM> GenerateTransfersOverviewVM()
        {
            string currentAccount = await GetCurrentAccountNumberAsync();

            var transfersVM = await GetTransfersAsync(currentAccount);

            return new TransfersOverviewVM()
            {
                Transfers = transfersVM,
                AccountNumber = currentAccount
            };
        }

        private async Task<List<TransferVM>> GetTransfersAsync(string currentAccount)
        {
            await AddBearerToken();
            var transfers = await _client.TransfersGetAllAsync(currentAccount);

            if (transfers == null || transfers.Count < 1)
            {
                return new List<TransferVM>();
            }

            var transferList = _mapper.Map<List<TransferVM>>(transfers);

            return transferList;
        }
    }
}
