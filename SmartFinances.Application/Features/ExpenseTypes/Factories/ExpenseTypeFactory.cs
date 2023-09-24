using AutoMapper;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Features.ExpenseTypes.Factories
{
    public class ExpenseTypeFactory : IExpenseTypeFactory
    {
        private readonly IMapper _mapper;

        public ExpenseTypeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ExpenseType CreateExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            return _mapper.Map<ExpenseType>(expenseTypeDto);
        }

        public ExpenseTypeDto CreateExpenseTypeDto(ExpenseType expenseType)
        {
            return _mapper.Map<ExpenseTypeDto>(expenseType);
        }

        public List<ExpenseTypeDto> CreateExpenseTypeDtoList(List<ExpenseType> expenseTypes)
        {
            return _mapper.Map<List<ExpenseTypeDto>>(expenseTypes);
        }

        public ExpenseType MapToModel(ExpenseTypeDto expenseTypeDto, ExpenseType model)
        {
            return _mapper.Map(expenseTypeDto, model);
        }

        public ExpenseType MapToModel(EditExpenseTypeDto expenseTypeDto, ExpenseType model)
        {
            return _mapper.Map(expenseTypeDto, model);
        }
    }
}
