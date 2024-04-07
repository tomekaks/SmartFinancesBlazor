using AutoMapper;
using Blazored.LocalStorage;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Models.AccountTypes;
using SmartFinancesBlazorUI.Models.Admin;
using SmartFinancesBlazorUI.Services.Base;

namespace SmartFinancesBlazorUI.Services
{
    public class AccountTypesService : BaseHttpService, IAccountTypesService
    {
        private readonly IMapper _mapper;

        public AccountTypesService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<AccountTypeVM>> GetAllAsync()
        {
            await AddBearerToken();
            var accountTypesDto = await _client.AccountTypesAsync();

            if(accountTypesDto == null || !accountTypesDto.Any())
            {
                return new List<AccountTypeVM>();
            }

            var accountTypesVM = _mapper.Map<List<AccountTypeVM>>(accountTypesDto);
            return accountTypesVM;
        }
    }
}
