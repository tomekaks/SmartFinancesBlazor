using AutoMapper;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models.Contacts;
using System.Net.Http;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class ContactsService : IContactsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ContactsService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<ContactVM>> GetContacts(string accountNumber)
        {
            var response = await _httpClient.GetAsync($"api/contacts/{accountNumber}");
            if (!response.IsSuccessStatusCode)
            {
                return new List<ContactVM>();
            }

            var contacts = await response.Content.ReadFromJsonAsync<List<ContactVM>>();
            return _mapper.Map<List<ContactVM>>(contacts);
        }
    }
}
