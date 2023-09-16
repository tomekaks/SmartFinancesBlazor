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

        public async Task<List<TransferVM>> GetTransfersAsync()
        {
            string currentAccount = await _localStorage.GetItemAsync<string>(Constants.CURRENTACCOUNT);

            await AddBearerToken();
            var transfers = await _client.TransfersGetAllAsync(currentAccount);

            if(transfers == null)
            {
                return new List<TransferVM>();
            }

            var transferList = _mapper.Map<List<TransferVM>>(transfers);

            return transferList ?? new List<TransferVM>();
        }

        public async Task<bool> CreateTransferAsync(NewTransferVM transferVM)
        {
            transferVM.SendTime= DateTime.Now;
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);
            transferDto.SenderAccountNumber = await GetCurrentAccountNumberAsync();

            await AddBearerToken();
            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

        public async Task<string> GetCurrentAccountNumberAsync()
        {
            return await _localStorage.GetItemAsync<string>(Constants.CURRENTACCOUNT);
        }

    }
}
