using MediatR;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Queries
{
    public class GetMainTransactionalAccountRequestHandler
        : IRequestHandler<GetMainTransactionalAccountRequest, TransactionalAccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionalAccountFactory _transactionalAccountFactory;

        public GetMainTransactionalAccountRequestHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task<TransactionalAccountDto> Handle(GetMainTransactionalAccountRequest request, CancellationToken cancellationToken)
        {
            var transactionalAccount = await _unitOfWork.TransactionalAccounts.GetAsync(q => q.UserId == request.UserId && q.Type == 1);

            if (transactionalAccount == null)
            {
                throw new NotFoundException("TransactionalAccount", request.UserId);
            }

            return _transactionalAccountFactory.CreateTransactionalAccountDto(transactionalAccount);
        }
    }
}
