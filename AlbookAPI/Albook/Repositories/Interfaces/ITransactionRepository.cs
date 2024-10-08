﻿using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task AddTransactionAsync(Transaction transaction);
    }
}
