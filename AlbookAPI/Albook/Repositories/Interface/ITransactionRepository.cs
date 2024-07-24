using Albook.Models.Domain;
using System.Threading.Tasks;

namespace Albook.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task AddTransactionAsync(Transaction transaction);
    }
}
