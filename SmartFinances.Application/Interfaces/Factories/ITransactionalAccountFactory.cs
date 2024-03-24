using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface ITransactionalAccountFactory
    {
        TransactionalAccount CreateTransactionalAccount(CreateTransactionalAccountDto accountDto, string userName);
        TransactionalAccount CreateMainAccount(string userId, string userName);
        TransactionalAccountDto CreateTransactionalAccountDto(TransactionalAccount transactionalAccount);
        TransactionalAccount MapToModel(UpdateTransactionalAccountDto dto, TransactionalAccount model);
        List<TransactionalAccountDto> CreateTransactionalAccountDtoList(List<TransactionalAccount> transactionalAccounts);
    }
}
