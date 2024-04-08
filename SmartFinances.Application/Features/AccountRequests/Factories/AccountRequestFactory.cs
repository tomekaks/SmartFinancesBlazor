using AutoMapper;
using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.AccountRequests.Factories
{
    public class AccountRequestFactory : IAccountRequestFactory
    {
        private readonly IMapper _mapper;

        public AccountRequestFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public AccountRequest CreateAccountRequest(CreateAccountRequestDto createAccountRequestDto)
        {
            return new AccountRequest()
            {
                UserId = createAccountRequestDto.UserId,
                Type = createAccountRequestDto.Type,
                Status = Constants.STATUS_PENDING,
                DateRequested = DateTime.UtcNow
            };
        }

        public AccountRequestDto CreateAccountRequestDto(AccountRequest accountRequest)
        {
            return _mapper.Map<AccountRequestDto>(accountRequest);
        }

        public List<AccountRequestDto> GetAccountRequestDtoList(List<AccountRequest> accountRequests)
        {
            return _mapper.Map<List<AccountRequestDto>>(accountRequests);
        }
    }
}
