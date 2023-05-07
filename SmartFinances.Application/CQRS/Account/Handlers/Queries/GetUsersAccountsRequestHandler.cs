using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Queries;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Handlers.Queries
{
    public class GetUsersAccountsRequestHandler : IRequestHandler<GetUsersAccountsRequest, List<AccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersAccountsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AccountDto>> Handle(GetUsersAccountsRequest request, CancellationToken cancellationToken)
        {
            var accounts = await _unitOfWork.Accounts.GetAllAsync(q => q.UserId == request.UserId);

            return _mapper.Map<List<AccountDto>>(accounts);
        }
    }
}
