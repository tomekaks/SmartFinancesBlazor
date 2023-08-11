using AutoMapper;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.RegularExpenses.Factories
{
    public class RegularExpenseFactory : IRegularExpenseFactory
    {
        private readonly IMapper _mapper;

        public RegularExpenseFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RegularExpense CreateRegularExpense(RegularExpenseDto regularExpenseDto)
        {
            return _mapper.Map<RegularExpense>(regularExpenseDto);
        }

        public RegularExpenseDto CreateRegularExpenseDto(RegularExpense regularExpense)
        {
            return _mapper.Map<RegularExpenseDto>(regularExpense);
        }

        public List<RegularExpenseDto> CreateRegularExpenseDtoList(List<RegularExpense> regularExpenses)
        {
            return _mapper.Map<List<RegularExpenseDto>>(regularExpenses);
        }

        public RegularExpense MapToModel(RegularExpenseDto regularExpenseDto, RegularExpense model)
        {
            return _mapper.Map(regularExpenseDto, model);
        }
    }
}
