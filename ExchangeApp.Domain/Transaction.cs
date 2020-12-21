using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeApp.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeRate { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
    }
}
