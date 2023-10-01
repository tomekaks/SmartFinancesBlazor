using MediatR;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;

namespace SmartFinances.Application.Features.ExpenseTypes.Requests.Queries
{
    public class GetExpenseTypesRequest : IRequest<List<ExpenseTypeDto>>
    {
    }
}
