using System.ComponentModel.DataAnnotations;

namespace SmartFinancesBlazorUI.Models.Transfers
{
    public class TransferVM
    {
        public string SenderName { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }

        public string CurrentAccountNumber { get; set; }
        public string OtherPartyName => CurrentAccountNumber == SenderAccountNumber ? ReceiverName : SenderName;
        public string OtherPartyAccountNumber => CurrentAccountNumber == SenderAccountNumber ? ReceiverAccountNumber : SenderAccountNumber;
    }
}
