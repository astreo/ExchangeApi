using ExchangeApp.Data;
using ExchangeApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApi.Services
{
    public class TransactionRepository: ITransactionRepository, IDisposable
    {
        private DataContext _context;
        public TransactionRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddTransaction(Transaction transactionToAdd)
        {
            if (transactionToAdd == null)
            {
                throw new ArgumentNullException(nameof(transactionToAdd));
            }

            _context.Add(transactionToAdd);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }

        public decimal MonthSum(int userId, int month, int year)
        {
            return _context.Transactions.Where(x => x.UserId == userId && x.Date.Month == month && x.Date.Year == year).Sum(x => x.Amount);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
