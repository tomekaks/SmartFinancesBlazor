using SmartFinances.Application.Features.Accounts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Dtos
{
    public class OutgoingTransferDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public int AccountId { get; set; }
        public AccountDto AccountDto { get; set; }
        public string Title { get; set; }
    }
}
