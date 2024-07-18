namespace Albook.Models.Domain
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
        public string Role { get; set; } // Add this property
    }
}
