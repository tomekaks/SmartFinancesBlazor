using SmartFinances.Application.Features.Expenses.Dtos;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IExpenseFactory
    {
        Expense CreateExpense(ExpenseDto expenseDto);
        ExpenseDto CreateExpenseDto(Expense expense);
        Expense MapToModel(ExpenseDto expenseDto, Expense model);
        Expense MapToModel(EditExpenseDto expenseDto, Expense model);
        List<ExpenseDto> CreateExpenseDtoList(List<Expense> expenses);
    }
}
