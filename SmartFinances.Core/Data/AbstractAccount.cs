namespace SmartFinances.Core.Data
{
    public abstract class AbstractAccount
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreationDateTime { get; set; }

    }
}
