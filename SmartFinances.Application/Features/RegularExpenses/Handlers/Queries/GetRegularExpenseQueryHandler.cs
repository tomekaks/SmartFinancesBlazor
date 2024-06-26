﻿using MediatR;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.RegularExpenses.Handlers.Queries
{
    public class GetRegularExpenseQueryHandler : IRequestHandler<GetRegularExpenseQuery, RegularExpenseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegularExpenseFactory _regularExpenseFactory;

        public GetRegularExpenseQueryHandler(IUnitOfWork unitOfWork, IRegularExpenseFactory regularExpenseFactory)
        {
            _unitOfWork = unitOfWork;
            _regularExpenseFactory = regularExpenseFactory;
        }

        public async Task<RegularExpenseDto> Handle(GetRegularExpenseQuery request, CancellationToken cancellationToken)
        {
            var regularExpense = await _unitOfWork.RegularExpenses.GetAsync(q => q.Id == request.Id);

            if (regularExpense == null)
            {
                return new RegularExpenseDto();
            }

            return _regularExpenseFactory.CreateRegularExpenseDto(regularExpense);
        }
    }
}
