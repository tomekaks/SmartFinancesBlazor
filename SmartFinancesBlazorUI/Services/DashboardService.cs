using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models;

namespace SmartFinancesBlazorUI.Services
{
    public class DashboardService : IDashboardService
    {
        //public List<AccountDto> GetAccounts()
        //{
        //    return new List<AccountDto>();
        //}

        public List<AccountDto> GetAccounts()
        {
            return new List<AccountDto>()
            {
                new AccountDto()
                {
                    Number = "AAAA1234AAAA",
                    Balance = 10000,
                    Budget = 1000
                },

                new AccountDto()
                {
                    Number = "BBBB1234BBBB",
                    Balance = 10000,
                    Budget = 2000
                },

                new AccountDto()
                {
                    Number = "CCCC1234CCCC",
                    Balance = 10000,
                    Budget = 1500
                },
            };
        }
    }
}
