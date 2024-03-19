using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface ISavingsAccountFactory
    {
        SavingsAccount CreateSavingsAccount(string userId, string userName);
        SavingsAccountDto CreateSavingsAccountDto(SavingsAccount savingsAccount);
        SavingsAccount MapToModel(UpdateSavingsAccountDto updateSavingsAccountDto, SavingsAccount savingsAccount);
    }
}
