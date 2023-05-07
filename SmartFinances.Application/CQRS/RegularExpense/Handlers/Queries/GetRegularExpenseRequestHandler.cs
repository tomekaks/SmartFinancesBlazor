using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.RegularExpense.Requests.Queries;
using SmartFinances.Application.Dto.RegularExpenseDtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.RegularExpense.Handlers.Queries
{
    public class GetRegularExpenseRequestHandler : IRequestHandler<GetRegularExpenseRequest, RegularExpenseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegularExpenseFactory _regularExpenseFactory;

        public GetRegularExpenseRequestHandler(IUnitOfWork unitOfWork, IRegularExpenseFactory regularExpenseFactory)
        {
            _unitOfWork = unitOfWork;
            _regularExpenseFactory = regularExpenseFactory;
        }

        public async Task<RegularExpenseDto> Handle(GetRegularExpenseRequest request, CancellationToken cancellationToken)
        {
            var regularExpense = await _unitOfWork.RegularExpenses.GetAsync(q => q.Id == request.Id);
            return _regularExpenseFactory.CreateRegularExpenseDto(regularExpense);
        }
    }
}
