using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IRegularExpenseFactory
    {
        RegularExpense CreateRegularExpense(RegularExpenseDto regularExpenseDto);
        RegularExpenseDto CreateRegularExpenseDto(RegularExpense regularExpense);
        RegularExpense MapToModel(RegularExpenseDto regularExpenseDto, RegularExpense model);
        List<RegularExpenseDto> CreateRegularExpenseDtoList(List<RegularExpense> regularExpenses);
    }
}
