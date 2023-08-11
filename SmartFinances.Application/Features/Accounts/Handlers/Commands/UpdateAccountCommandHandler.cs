using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Accounts.Requests.Commands;
using SmartFinances.Application.Features.Accounts.Validators;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.Accounts.Handlers.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAccountCommandHandler(IAccountFactory accountFactory, IUnitOfWork unitOfWork)
        {
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAccountCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var account = await _unitOfWork.Accounts.GetAsync(q => q.Id == request.UpdateAccountDto.Id);
            account = _accountFactory.MapToModel(request.UpdateAccountDto, account);

            _unitOfWork.Accounts.Update(account);
            await _unitOfWork.SaveAsync();

            return;
        }
    }
}
