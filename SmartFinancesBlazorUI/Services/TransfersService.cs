using AutoMapper;
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

        public TransfersService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<List<TransferVM>> GetTransfers(string accountNumber)
        {
            var transfers = await _client.TransfersAllAsync(accountNumber);

            var transferList = _mapper.Map<List<TransferVM>>(transfers);

            return transferList ?? new List<TransferVM>();
        }

        public async Task<bool> CreateTransfer(NewTransferVM transferVM)
        {
            var transferDto = _mapper.Map<CreateTransferDto>(transferVM);

            await _client.TransfersPOSTAsync(transferDto);

            return true;
        }

    }
}
