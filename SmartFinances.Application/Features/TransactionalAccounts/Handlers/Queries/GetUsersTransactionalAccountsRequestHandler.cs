using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Queries
{
    public class GetUsersTransactionalAccountsRequestHandler 
        : IRequestHandler<GetUsersTransactionalAccountsRequest, List<TransactionalAccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionalAccountFactory _transactionalAccountFactory;

        public GetUsersTransactionalAccountsRequestHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task<List<TransactionalAccountDto>> Handle(GetUsersTransactionalAccountsRequest request, CancellationToken cancellationToken)
        {
            var transactionalAccounts = await _unitOfWork.TransactionalAccounts.GetAllAsync(q => q.UserId == request.UserId);

            return _transactionalAccountFactory.CreateTransactionalAccountDtoList(transactionalAccounts.ToList());
        }
    }
}
