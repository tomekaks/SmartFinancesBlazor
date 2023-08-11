using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Dtos
{
    public class IncomingTransferDto
    {
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public string SenderName { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string Title { get; set; }
    }
}
