using MediatR;
using SmartFinances.Application.Features.RegularExpenses.Dtos;

namespace SmartFinances.Application.Features.RegularExpenses.Requests.Commands
{
    public class UpdateRegularExpenseCommand : IRequest
    {
        public EditRegularExpenseDto RegularExpenseDto { get; set; }
    }
}
