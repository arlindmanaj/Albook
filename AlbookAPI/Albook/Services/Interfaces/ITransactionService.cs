using Albook.Models.Domain;

namespace Albook.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
    }
}
