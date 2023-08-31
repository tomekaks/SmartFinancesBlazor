using SmartFinancesBlazorUI.Models.Contacts;

namespace SmartFinancesBlazorUI.Contracts
{
    public interface IContactsService
    {
        Task<ContactVM> GetContact(int contactId);
        List<ContactVM> GetContactsTemp();
        Task<List<ContactVM>> GetContacts(string accountNumber);
        Task<bool> CreateContact(NewContactVM contact);
        Task<bool> UpdateContact(NewContactVM contact);
        Task<bool> DeleteContact(int contactId);
    }
}
