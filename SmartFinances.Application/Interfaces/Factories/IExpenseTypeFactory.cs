using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IExpenseTypeFactory
    {
        ExpenseType CreateExpenseType(ExpenseTypeDto expenseTypeDto);
        ExpenseTypeDto CreateExpenseTypeDto(ExpenseType expenseType);
        ExpenseType MapToModel(ExpenseTypeDto expenseTypeDto, ExpenseType model);
        ExpenseType MapToModel(EditExpenseTypeDto expenseTypeDto, ExpenseType model);
        List<ExpenseTypeDto> CreateExpenseTypeDtoList(List<ExpenseType> expenseTypes);
    }
}
