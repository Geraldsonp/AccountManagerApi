using System;
using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;
using DataAccessLayer.Models;


namespace DataAccessLayer.Repos
{
    public class TransactionRepository : CrudBaseRepo<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AccountsManagerDbContext context) : base(context)
        {
        }
    }
}
