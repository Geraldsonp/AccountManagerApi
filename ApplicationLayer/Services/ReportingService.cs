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



        public async Task<IEnumerable<AccountStatusReport>> GetAccountStatusReport(int clientId, DateTime? startDate, DateTime? endDate)
        {
            var client = await _clientRepository.Get(x => x.ClientId == clientId);

            var accounts = await _accountRepository.GetAccountsWithTransactions(clientId);

            List<AccountStatusReport> reports = new List<AccountStatusReport>();

            foreach (var account in accounts)
            {
                var report = new AccountStatusReport
                {
                    Client = client.Name,
                    AccountNumber = account.AccountNumber,
                    InitialBalance = account.InitialBalance,
                    Transaction = account.Transactions.Where(x => x.Date.Date >= startDate && x.Date.Date <= endDate).Sum(x => x.Amount),
                    AvailableBalance = account.GetCurrentBalance()
                };
                reports.Add(report);
            }

            return reports;
        }

    }
}
