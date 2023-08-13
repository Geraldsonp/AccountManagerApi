using System;
using ApplicationLayer.Domain;
using ApplicationLayer.Domain.Contracts;


namespace ApplicationLayer.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<Transaction> CreateTransactionAsync(string accountNumber, decimal amount)
        {
            ValidateAccountExists(accountNumber);

            var account = await _accountRepository.GetAccountWithTransactions(accountNumber);

            var transaction = new Transaction(amount, accountNumber);

            var currentBalance = account.ProccesTransaction(transaction);

            return await _transactionRepository.Create(transaction);
        }


        public async Task DeleteTransactionAsync(int id, string accountNumber)
        {
            ValidateAccountExists(accountNumber);
            var transaction = await _transactionRepository.Get(t => t.TransactionId == id && t.AccountNumber == accountNumber);
            await _transactionRepository.Delete(transaction);
        }

        public async Task<Transaction> GetTransactionAsync(int transactionId, string accountNumber)
        {
            ValidateAccountExists(accountNumber);
            return await _transactionRepository.Get(t => t.TransactionId == transactionId && t.AccountNumber == accountNumber);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(string accountNumber)
        {
            ValidateAccountExists(accountNumber);
            return await _transactionRepository.GetAll(t => t.AccountNumber == accountNumber);
        }

        private void ValidateAccountExists(string accountNumber)
        {
            if (!_accountRepository.DoesAccountExist(accountNumber))
                throw new NotFoundException(nameof(Account), accountNumber);
        }

    }
}
