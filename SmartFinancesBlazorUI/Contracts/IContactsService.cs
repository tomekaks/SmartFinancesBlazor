using SmartFinancesBlazorUI.Models.Contacts;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IContactsService
    {
        Task<ContactVM> GetContactAsync(int contactId);
        Task<List<ContactVM>> GetContactsAsync();
        Task<bool> CreateContactAsync(NewContactVM contact);
        Task<bool> UpdateContactAsync(NewContactVM contact);
        Task<bool> DeleteContactAsync(int contactId);
    }
}
