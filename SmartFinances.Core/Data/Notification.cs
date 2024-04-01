﻿namespace SmartFinances.Core.Data
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
