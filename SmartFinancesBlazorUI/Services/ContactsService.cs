using AutoMapper;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;
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

        public async Task<bool> CreateContact(NewContactVM contact)
        {
            var contactDto = _mapper.Map<ContactDto>(contact);

            var response = await _httpClient.PostAsJsonAsync("api/contacts", contactDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }

        public async Task<ContactVM> GetContact(int contactId)
        {
            var response = await _httpClient.GetAsync($"api/contacts/{contactId}");
            if (!response.IsSuccessStatusCode)
            {
                return new ContactVM();
            }

            var contact = await response.Content.ReadFromJsonAsync<ContactVM>();
            return _mapper.Map<ContactVM>(contact);
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

        public async Task<bool> UpdateContact(NewContactVM contact)
        {
            var contactDto = _mapper.Map<ContactDto>(contact);

            var response = await _httpClient.PutAsJsonAsync("api/contact", contactDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            var response = await _httpClient.DeleteAsync($"api/contact/{contactId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return false;
            }
            return true;
        }
    }
}
