using AutoMapper;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
using SmartFinancesBlazorUI.Models.Transfers;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class TransfersService : ITransfersService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public TransfersService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<TransferVM>> GetTransfers(string accountNumber)
        {
            var response = await _httpClient.GetAsync($"api/transfers/{accountNumber}");
            if (!response.IsSuccessStatusCode)
            {
                return new List<TransferVM>();
            }

            var transfers = await response.Content.ReadFromJsonAsync<List<TransferDto>>();
            return _mapper.Map<List<TransferVM>>(transfers);
        }

        public List<TransferVM> GetTransfers()
        {
            return new List<TransferVM>()
            {
                new TransferVM()
                {
                    Amount = 100,
                    SenderName = "AAA1234AAAA",
                    SenderAccountNumber = "AAA1234AAAA",
                    ReceiverName = "DDDD1234DDDD",
                    ReceiverAccountNumber = "DDDD1234DDDD",
                    Title = "test"
                },
                new TransferVM()
                {
                    Amount = 200,
                    SenderName = "DDDD1234DDDD",
                    SenderAccountNumber = "DDDD1234DDDD",
                    ReceiverName = "AAA1234AAAA",
                    ReceiverAccountNumber = "AAA1234AAAA",
                    Title = "test2"
                }
            };
        }

        public async Task<bool> CreateTransfer(NewTransferVM transferVM)
        {
            var transferDto = _mapper.Map<TransferDto>(transferVM);

            var response = await _httpClient.PostAsJsonAsync("api/transfers", transferDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }

    }
}
