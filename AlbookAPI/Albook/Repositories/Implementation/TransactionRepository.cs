using Albook.Data;
using Albook.Models.Domain;
using Albook.Repositories.Interfaces;

namespace Albook.Repositories.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            return await _context.Transactions.FindAsync(transactionId);
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
