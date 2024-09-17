using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface IBooksChapterRepository
    {
        Task<IEnumerable<BooksChapter>> GetChaptersByBookIdAsync(string bookId);
        Task AddBooksChapterAsync(BooksChapter booksChapter);
        Task RemoveBooksChapterAsync(string bookId);
        Task SaveChangesAsync();
    }
}
