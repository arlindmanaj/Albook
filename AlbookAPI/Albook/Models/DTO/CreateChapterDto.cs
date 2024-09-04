namespace Albook.Models.DTO
{
    public class CreateChapterDto
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
    }
}
