using Albook.Models.Domain;

namespace Albook.Repositories.Interface
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
    }
}
