using MediatR;
using SmartFinances.Application.Features.RegularExpenses.Dtos;
using SmartFinances.Application.Features.RegularExpenses.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.RegularExpenses.Handlers.Queries
{
    public class GetRegularExpenseListRequestHandler : IRequestHandler<GetRegularExpenseListRequest, List<RegularExpenseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegularExpenseFactory _regularExpenseFactory;

        public GetRegularExpenseListRequestHandler(IUnitOfWork unitOfWork, IRegularExpenseFactory regularExpenseFactory)
        {
            _unitOfWork = unitOfWork;
            _regularExpenseFactory = regularExpenseFactory;
        }

        public async Task<List<RegularExpenseDto>> Handle(GetRegularExpenseListRequest request, CancellationToken cancellationToken)
        {
            var regularExpenseList = await _unitOfWork.RegularExpenses.GetAllAsync(q => q.AccountId == request.AccountId, 
                                                                                   includeProperties: Constants.EXPENSETYPE);

            if (regularExpenseList == null || !regularExpenseList.Any())
            {
                return new List<RegularExpenseDto>();
            }

            return _regularExpenseFactory.CreateRegularExpenseDtoList(regularExpenseList.ToList());
        }
    }
}
