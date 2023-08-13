using System;
using ApplicationLayer.Domain.Contracts;
using ApplicationLayer.Domain.Enums;
using ApplicationLayer.Domain.Reports;

namespace ApplicationLayer.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAccountRepository _accountRepository;

        public ReportingService(IClientRepository clientRepository, IAccountRepository accountRepository)
        {
            _clientRepository = clientRepository;
            _accountRepository = accountRepository;

        }



        public async Task<AccountStatusReport> GetAccountStatusReport(int clientId, DateTime? startDate, DateTime? endDate)
        {
            var client = await _clientRepository.Get(x => x.ClientId == clientId);

            var accounts = await _accountRepository.GetAccountsWithTransactions(clientId);

            var report = new AccountStatusReport
            {
                ClientId = clientId,
            };

            foreach (var account in accounts)
            {
                var accountStatus = new AccountStatus
                {
                    AccountNumber = account.AccountNumber,
                    CurrentBalance = account.GetCurrentBalance(),
                    DebitsTotal = account.Transactions.Where(x => x.TransactionType == TransactionType.Debit
                        && x.Date.Date >= startDate && x.Date.Date <= endDate).Sum(x => x.Amount),
                    CreditsTotal = account.Transactions.Where(x => x.TransactionType == TransactionType.Credit
                        && x.Date.Date >= startDate && x.Date.Date <= endDate).Sum(x => x.Amount)
                };

                report.Accounts.Add(accountStatus);
            }

            return report;
        }

    }
}
