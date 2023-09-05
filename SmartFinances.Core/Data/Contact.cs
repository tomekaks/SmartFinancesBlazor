namespace SmartFinances.Core.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
