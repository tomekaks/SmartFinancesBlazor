﻿using Microsoft.AspNetCore.Identity;

namespace SmartFinances.Core.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Contact> Contacts { get; set; }
        public bool IsSuspended { get; set; } = false;
        public string SuspensionReason { get; set; }
    }
}
