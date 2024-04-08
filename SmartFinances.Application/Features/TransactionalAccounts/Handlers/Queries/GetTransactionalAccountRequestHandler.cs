using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Queries
{
    public class GetTransactionalAccountRequestHandler
        : IRequestHandler<GetTransactionalAccountRequest, TransactionalAccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionalAccountFactory _transactionalAccountFactory;

        public GetTransactionalAccountRequestHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task<TransactionalAccountDto> Handle(GetTransactionalAccountRequest request, CancellationToken cancellationToken)
        {
            var transactionalAccount = await _unitOfWork.TransactionalAccounts.GetAsync(q =>
                    q.Id == request.AccountId, includeProperties: Constants.ACCOUNTTYPE);

            if (transactionalAccount == null)
            {
                throw new NotFoundException("TransactionalAccount", request.AccountId);
            }

            return _transactionalAccountFactory.CreateTransactionalAccountDto(transactionalAccount);
        }
    }
}
