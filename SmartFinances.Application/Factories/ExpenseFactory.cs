using AutoMapper;
using SmartFinances.Application.Dto.ExpenseDtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Factories
{
    public class ExpenseFactory : IExpenseFactory
    {
        private readonly IMapper _mapper;

        public ExpenseFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Expense CreateExpense(ExpenseDto expenseDto)
        {
            return _mapper.Map<Expense>(expenseDto);
        }

        public ExpenseDto CreateExpenseDto(Expense expense)
        {
            return _mapper.Map<ExpenseDto>(expense);
        }

        public List<ExpenseDto> CreateExpenseDtoList(List<Expense> expenses)
        {
            return _mapper.Map<List<ExpenseDto>>(expenses);
        }

        public Expense MapToModel(ExpenseDto expenseDto, Expense model)
        {
            return _mapper.Map(expenseDto, model);
        }
        public Expense MapToModel(EditExpenseDto expenseDto, Expense model)
        {
            return _mapper.Map(expenseDto, model);
        }

    }
}
