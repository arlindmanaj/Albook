using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albook.Models.Domain
{
    public class BookReview
    {
        
        public int ReviewId { get; set; }

        
        public string BookId { get; set; }

       
        public Book Book { get; set; }

        
        public int UserId { get; set; }

        
        public User User { get; set; }

        
        public string ReviewText { get; set; }

       
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
