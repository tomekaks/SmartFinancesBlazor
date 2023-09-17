using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Services.Base;
using System.Net.Http.Json;

namespace SmartFinancesBlazorUI.Services
{
    public class ContactsService : BaseHttpService, IContactsService
    {
        private readonly IMapper _mapper;

        public ContactsService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<bool> CreateContactAsync(NewContactVM newContact)
        {
            var contacts = await GetContactsAsync();

            var result = contacts.FirstOrDefault(q => q.Name == newContact.Name);
            if (result != null)
            {
                return true;
            }

            var contactDto = _mapper.Map<ContactDto>(newContact);

            await AddBearerToken();
            await _client.ContactsPOSTAsync(contactDto);

            return true;
        }

        public async Task<ContactVM> GetContactAsync(int contactId)
        {
            await AddBearerToken();
            var contact = await _client.ContactsGETAsync(contactId);

            if (contact == null)
            {
                return new ContactVM();
            }

            return _mapper.Map<ContactVM>(contact);
        }

        public async Task<List<ContactVM>> GetContactsAsync()
        {
            await AddBearerToken();
            var contacts = await _client.ContactsAllAsync();

            var contactList = _mapper.Map<List<ContactVM>>(contacts);

            return contactList ?? new List<ContactVM>();
        }

        public async Task<bool> UpdateContactAsync(ContactVM contact)
        {
            var contactDto = _mapper.Map<ContactDto>(contact);

            await AddBearerToken();
            await _client.ContactsPUTAsync(contactDto);

            return true;
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            await AddBearerToken();
            await _client.ContactsDELETEAsync(contactId);

            return true;
        }
    }
}
