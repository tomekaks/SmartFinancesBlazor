using MediatR;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;

namespace SmartFinances.Application.Features.SavingsAccounts.Requests.Queries
{
    public class GetSavingsAccountQuery : IRequest<SavingsAccountDto>
    {
        public string UserId { get; set; }
    }
}
