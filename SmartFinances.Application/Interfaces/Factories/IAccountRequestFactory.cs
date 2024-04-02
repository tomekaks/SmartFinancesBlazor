using SmartFinances.Application.Features.AccountRequests.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IAccountRequestFactory
    {
        AccountRequest CreateAccountRequest(CreateAccountRequestDto createAccountRequestDto);
        AccountRequestDto CreateAccountRequestDto(AccountRequest accountRequest);
        List<AccountRequestDto> GetAccountRequestDtoList(List<AccountRequest> accountRequests);
    }
}
