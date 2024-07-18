namespace Albook.Models.DTO
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
    }
}
