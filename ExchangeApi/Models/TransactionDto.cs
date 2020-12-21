using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeApi.Models
{
    public class TransactionDto
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeRate { get; set; }
        public string Currency { get; set; }
    }
}
