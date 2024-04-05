using SmartFinances.Application.Features.AccountTypes.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IAccountTypeFactory
    {
        AccountType CreateAccountType(AccountTypeDto accountTypeDto);
        AccountTypeDto CreateAccountTypeDto(AccountType accountType);
        List<AccountTypeDto> CreateAccountTypeDtoList(List<AccountType> accountTypes);
    }
}
