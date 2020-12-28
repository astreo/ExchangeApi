using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeApp.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        readonly string[] currencies = new string[] { "usd", "brl" };

       
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetTransactions()
        {
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            foreach (var item in currencies)
            {
                ExchangeRate exchangeRate = Utils.GetExchangeRate(item);
                exchangeRates.Add(exchangeRate);
            }
                
            return Ok(exchangeRates);
        }
        



        // GET api/<ExchangeRatesController>/5
        [HttpGet("{id}")]
        public string GetExchange(string id)
        {
            if (currencies.Contains(id.ToLower()))
            {
                ExchangeRate exchangeRate = Utils.GetExchangeRate(id);
                return exchangeRate.SellVal.ToString();
            }
            return "Tipo de cambio no corresponde";
        }

    }

}

    
