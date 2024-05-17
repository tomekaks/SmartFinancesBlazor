using MediatR;
using SmartFinances.Application.Features.Expenses.Dtos;

namespace SmartFinances.Application.Features.Expenses.Requests.Queries
{
    public class GetExpenseListQuery : IRequest<List<ExpenseDto>>
    {
        public int MonthlySummaryId { get; set; }
    }
}
