using AutoMapper;
using SmartFinances.Application.Features.AccountTypes.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.AccountTypes.Factories
{
    public class AccountTypeFactory : IAccountTypeFactory
    {
        private readonly IMapper _mapper;

        public AccountTypeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AccountType CreateAccountType(AccountTypeDto accountTypeDto)
        {
            return _mapper.Map<AccountType>(accountTypeDto);
        }

        public AccountTypeDto CreateAccountTypeDto(AccountType accountType)
        {
            return _mapper.Map<AccountTypeDto>(accountType);
        }

        public List<AccountTypeDto> CreateAccountTypeDtoList(List<AccountType> accountTypes)
        {
            return _mapper.Map<List<AccountTypeDto>>(accountTypes);
        }
    }
}
