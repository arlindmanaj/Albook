using System;
using System.ComponentModel.DataAnnotations;

namespace Albook.Models.DTO
{
    public class BookReviewDTO
    {
        public int ReviewId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string ReviewText { get; set; }

        [Required]
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
