using MediatR;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.SavingsAccounts.Handlers.Queries
{
    public class GetSavingsAccountRequestHandler : IRequestHandler<GetSavingsAccountRequest, SavingsAccountDto>
    {
        private readonly ISavingsAccountFactory _savingsAccountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public GetSavingsAccountRequestHandler(ISavingsAccountFactory savingsAccountFactory, IUnitOfWork unitOfWork)
        {
            _savingsAccountFactory = savingsAccountFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<SavingsAccountDto> Handle(GetSavingsAccountRequest request, CancellationToken cancellationToken)
        {
            var savingsAccount = await _unitOfWork.SavingsAccounts.GetAsync(q => q.UserId == request.UserId);

            if (savingsAccount == null)
            {
                return null;
            }

            return _savingsAccountFactory.CreateSavingsAccountDto(savingsAccount);
        }
    }
}
