using ExchangeApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApi.Services
{
    public interface ITransactionRepository : IDisposable
    {
        void AddTransaction(Transaction transactionToAdd);
        decimal MonthSum(int userId, int month, int year);
        Task<bool> SaveChangesAsync();
    }
}
