using SmartFinances.Application.Features.AccountTypes.Dtos;
using SmartFinances.Application.Features.Users.Dtos;

namespace SmartFinances.Application.Features.AccountRequests.Dtos
{
    public class AccountRequestDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserDto UserDto { get; set; }
        public string Type { get; set; }
        public int AccountTypeId { get; set; }
        public AccountTypeDto AccountTypeDto { get; set; }
        public string Status { get; set; }
        public DateTime DateRequested { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? DateApproved { get; set; }
        public string RejectedBy { get; set; }
        public DateTime? DateRejected { get; set; }
    }
}
