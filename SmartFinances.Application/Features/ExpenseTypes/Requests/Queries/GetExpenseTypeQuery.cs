using MediatR;
using SmartFinances.Application.Features.ExpenseTypes.Dtos;

namespace SmartFinances.Application.Features.ExpenseTypes.Requests.Queries
{
    public class GetExpenseTypeQuery : IRequest<ExpenseTypeDto>
    {
        public int ExpenseTypeId { get; set; }
    }
}
