﻿using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface IBookReviewRepository
    {
        Task<IEnumerable<BookReview>> GetBookReviewsAsync();
        Task<BookReview> GetBookReviewByIdAsync(string id);
        Task AddBookReviewAsync(BookReview review);
        Task UpdateBookReviewAsync(BookReview review);
        Task DeleteBookReviewAsync(BookReview review);
    }
}
