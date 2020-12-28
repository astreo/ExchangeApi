using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExchangeApp.Data;
using ExchangeApp.Domain;
using AutoMapper;
using ExchangeApi.Models;

using ExchangeApi.Services;

namespace ExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // private readonly DataContext _context;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(TransactionDto transactionDto)
        {
            string errMsg;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            decimal monthSum = _transactionRepository.MonthSum(transactionDto.UserId, currentMonth, currentYear);
            if (Utils.ValidateAmount((monthSum + transactionDto.Amount), transactionDto.Currency))
            {
                Transaction transaction = _mapper.Map<Transaction>(transactionDto);
                transaction.Date = DateTime.Now;
                _transactionRepository.AddTransaction(transaction);
                await _transactionRepository.SaveChangesAsync();

                return CreatedAtAction("PostTransaction", new { id = transaction.UserId }, new { result = transaction.Amount.ToString() + " / " + transaction.ChangeRate.ToString() + " " + transaction.Currency });
            } else
            {
                errMsg = "Sobrepasa el limite admitido";
            }
            return BadRequest(errMsg);
            
        }

    }

}
