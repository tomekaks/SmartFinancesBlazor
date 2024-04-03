namespace SmartFinancesBlazorUI.Contracts
{
    public interface IAccountRequestService
    {
        Task CreateAccountRequest(string accountType);
    }
}
