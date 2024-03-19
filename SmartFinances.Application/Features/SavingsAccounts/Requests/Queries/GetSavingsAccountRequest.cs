using MediatR;
using SmartFinances.Application.Features.SavingsAccounts.Dtos;

namespace SmartFinances.Application.Features.SavingsAccounts.Requests.Queries
{
    public class GetSavingsAccountRequest : IRequest<SavingsAccountDto>
    {
        public string UserId { get; set; }
    }
}
