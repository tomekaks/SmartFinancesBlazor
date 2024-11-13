using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models.Contacts;
using SmartFinancesBlazorUI.Services.Base;

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
            bool exists = await CheckIfContactExistsAsync(newContact.Name, newContact.AccountNumber);
            if (exists)
            {
                return false;
            }

            var contactDto = _mapper.Map<ContactDto>(newContact);

            await _client.ContactsPOSTAsync(contactDto);

            return true;
        }

        public async Task<ContactVM> GetContactAsync(int contactId)
        {
            var contact = await _client.ContactsGETAsync(contactId);

            if (contact == null)
            {
                return new ContactVM();
            }

            return _mapper.Map<ContactVM>(contact);
        }

        public async Task<List<ContactVM>> GetContactsAsync()
        {
            var contactsDto = await _client.ContactsAllAsync();

            if (contactsDto == null || !contactsDto.Any())
            {
                return new List<ContactVM>();
            }

            var contactsVM = _mapper.Map<List<ContactVM>>(contactsDto);

            return contactsVM;
        }

        public async Task<bool> UpdateContactAsync(ContactVM contact)
        {
            bool exists = await CheckIfContactExistsAsync(contact.Name, contact.AccountNumber);
            if (exists)
            {
                return false;
            }

            var contactDto = _mapper.Map<ContactDto>(contact);

            await _client.ContactsPUTAsync(contactDto);

            return true;
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            await _client.ContactsDELETEAsync(contactId);

            return true;
        }

        private async Task<bool> CheckIfContactExistsAsync(string name, string accountNumber)
        {
            var contacts = await GetContactsAsync();

            bool contactsExists = contacts.Any(q =>
            q.Name == name || q.AccountNumber == accountNumber);

            //var existingContact = contacts.FirstOrDefault(q => 
            //q.Name == name || q.AccountNumber == accountNumber);

            return contactsExists;
        }
    }
}
