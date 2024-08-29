using Newtonsoft.Json;

namespace Albook.Models.Domain
{
    public class BookReview
    {

        public int ReviewId { get; set; }

        public string BookId { get; set; }
      

        public int UserId { get; set; }

        

        public string ReviewText { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
