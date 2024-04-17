using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Features.Users.Dtos
{
    public class RegistrationResponse
    {
        public string UserId { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}
