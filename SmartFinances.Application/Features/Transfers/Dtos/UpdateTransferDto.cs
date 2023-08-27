using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Transfers.Dtos
{
    public class UpdateTransferDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public string Title { get; set; }
    }
}
