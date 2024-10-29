using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface ISavingsAccountFactory
    {
        SavingsAccount CreateSavingsAccount(CreateSavingsAccountDto accountDto, string userName);
        SavingsAccountDto CreateSavingsAccountDto(SavingsAccount savingsAccount);
    }
}
