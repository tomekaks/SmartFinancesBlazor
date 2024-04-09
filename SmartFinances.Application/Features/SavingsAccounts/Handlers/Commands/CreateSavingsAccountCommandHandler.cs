using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.SavingsAccounts.Requests.Commands;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.SavingsAccounts.Handlers.Commands
{
    public class CreateSavingsAccountCommandHandler : IRequestHandler<CreateSavingsAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavingsAccountFactory _savingsAccountFactory;

        public CreateSavingsAccountCommandHandler(IUnitOfWork unitOfWork, ISavingsAccountFactory savingsAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _savingsAccountFactory = savingsAccountFactory;
        }

        public async Task Handle(CreateSavingsAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.AccountDto.UserId);

            if (user == null)
            {
                throw new NotFoundException("User", request.AccountDto.UserId);
            }

            var savingsAccount = _savingsAccountFactory.CreateSavingsAccount(request.AccountDto, user.UserName);

            await _unitOfWork.SavingsAccounts.AddAsync(savingsAccount);
            await _unitOfWork.SaveAsync();
        }
    }
}
