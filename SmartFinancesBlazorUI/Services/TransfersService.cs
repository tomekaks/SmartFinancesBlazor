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

        public async Task<List<TransferVM>> GetTransfers(string accountNumber)
        {
            await AddBearerToken();
            var transfers = await _client.TransfersAllAsync(accountNumber);

            if(transfers == null)
            {
                return new List<TransferVM>();
            }

            var transferList = _mapper.Map<List<TransferVM>>(transfers);

            return transferList ?? new List<TransferVM>();
        }

        public async Task<bool> CreateTransfer(NewTransferVM transferVM)
        {
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);

            await AddBearerToken();
            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

    }
}
