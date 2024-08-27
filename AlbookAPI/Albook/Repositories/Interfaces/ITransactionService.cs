using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
    }
}
