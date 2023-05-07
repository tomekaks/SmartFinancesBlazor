using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Dto.Users
{
    public class UsersStatusDto
    {
        public string Id { get; set; }
        public bool IsSuspended { get; set; }
        public string SuspensionReason { get; set; }
    }
}
