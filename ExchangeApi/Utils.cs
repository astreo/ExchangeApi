using ExchangeApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExchangeApi
{
    public static class Utils
    {
        public static bool ValidateAmount(decimal amount, string currency)
        {
            bool result = false;
            switch (currency.ToLower())
            {
                case "usd":
                    result = amount <= 200;
                    break;

                case "brl":
                    result = amount <= 300;
                    break;
            }
            return result;
        }
        public static ExchangeRate GetExchangeRate(string currency)
        {
            string url = "";

            switch (currency.ToLower())
            {
                case "usd":
                    url = @"https://www.bancoprovincia.com.ar/Principal/Dolar";
                    break;
                case "brl":
                    url = @"https://www.bancoprovincia.com.ar/Principal/Dolar";
                    break;
            }

            using WebClient client = new WebClient();
            string reader = client.DownloadString(url);
            Console.WriteLine(reader);
            reader = reader.Replace("[", string.Empty).Replace("]", string.Empty).Replace("\"", string.Empty);
            string[] splitString = reader.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            ExchangeRate exchangeRate = new ExchangeRate
            {
                BuyVal = Convert.ToDecimal(splitString[0]),
                SellVal = Convert.ToDecimal(splitString[1]),
                Date = DateTime.Now
            };
            if (currency.ToLower() == "brl")
            {
                exchangeRate.BuyVal = exchangeRate.BuyVal / 4;
                exchangeRate.SellVal = exchangeRate.SellVal / 4;
            }
            return exchangeRate;
        }
    }
}
