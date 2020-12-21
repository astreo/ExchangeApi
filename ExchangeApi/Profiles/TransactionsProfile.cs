using AutoMapper;
using ExchangeApi.Models;
using ExchangeApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExchangeApi.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
