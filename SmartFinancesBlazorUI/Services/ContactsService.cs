using AutoMapper;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Services.Base;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class ContactsService : BaseHttpService, IContactsService
    {
        private readonly IMapper _mapper;

        public ContactsService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<bool> CreateContact(NewContactVM contact)
        {
            var contactDto = _mapper.Map<ContactDto>(contact);

            await _client.ContactsPOSTAsync(contactDto);

            return true;
        }

        public async Task<ContactVM> GetContact(int contactId)
        {
            var contact = await _client.ContactsGETAsync(contactId);

            return _mapper.Map<ContactVM>(contact);
        }

        public async Task<List<ContactVM>> GetContacts(string accountNumber)
        {
            var contacts = await _client.ContactsAllAsync(accountNumber);

            var contactList = _mapper.Map<List<ContactVM>>(contacts);

            return contactList ?? new List<ContactVM>();
        }

        public async Task<bool> UpdateContact(NewContactVM contact)
        {
            var contactDto = _mapper.Map<ContactDto>(contact);

            await _client.ContactsPUTAsync(contactDto);

            return true;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            await _client.ContactsDELETEAsync(contactId);

            return true;
        }
    }
}
