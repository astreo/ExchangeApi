﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeApp.Domain
{
    public class ExchangeRate
    {
        public decimal BuyVal { get; set; }
        public decimal SellVal { get; set; }
        public DateTime Date { get; set; }
    }
}
