using MediatR;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;

namespace SmartFinances.Application.Features.TransactionalAccounts.Handlers.Queries
{
    public class GetUsersTransactionalAccountsQueryHandler 
        : IRequestHandler<GetUsersTransactionalAccountsQuery, List<TransactionalAccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionalAccountFactory _transactionalAccountFactory;

        public GetUsersTransactionalAccountsQueryHandler(IUnitOfWork unitOfWork, ITransactionalAccountFactory transactionalAccountFactory)
        {
            _unitOfWork = unitOfWork;
            _transactionalAccountFactory = transactionalAccountFactory;
        }

        public async Task<List<TransactionalAccountDto>> Handle(GetUsersTransactionalAccountsQuery request, CancellationToken cancellationToken)
        {
            var transactionalAccounts = await _unitOfWork.TransactionalAccounts.GetAllAsync(q => 
                q.UserId == request.UserId, includeProperties: Constants.ACCOUNTTYPE);

            return _transactionalAccountFactory.CreateTransactionalAccountDtoList(transactionalAccounts.ToList());
        }
    }
}
