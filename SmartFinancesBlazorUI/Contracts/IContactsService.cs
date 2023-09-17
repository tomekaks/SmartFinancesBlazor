using SmartFinancesBlazorUI.Models.Contacts;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IContactsService
    {
        Task<ContactVM> GetContactAsync(int contactId);
        Task<List<ContactVM>> GetContactsAsync();
        Task<bool> CreateContactAsync(NewContactVM newContact);
        Task<bool> UpdateContactAsync(ContactVM contact);
        Task<bool> DeleteContactAsync(int contactId);
    }
}
