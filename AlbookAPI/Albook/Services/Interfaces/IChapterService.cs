﻿using Albook.Models.Domain;

namespace Albook.Services.Interfaces
{
    public interface IChapterService
    {
        Task<List<Chapter>> GetChaptersByBookIdAsync(string bookId);
        Task<Chapter> GetChapterByIdAsync(int chapterId);
        Task AddChaptersFromFileAsync(string bookId, IFormFile file);
        Task UpdateChapterAsync(int chapterId, Chapter updatedChapter);
        Task DeleteChapterAsync(int chapterId);
    }
}
