using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using ExchangeApp.Data;
using ExchangeApp.Domain;
using System.Diagnostics;

namespace Test1
{
    [TestClass]
    public class InMemoryTest
    {
        [TestMethod]
        public void CanInsertTransactionIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertTransaction");
            using (var context = new DataContext())
            {
                var transaction = new Transaction();
                context.Transactions.Add(transaction);
                Assert.AreEqual(EntityState.Added, context.Entry(transaction).State);

            }
        }
    }
}
