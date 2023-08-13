using System;
using ApplicationLayer.Domain.Reports;


namespace ApplicationLayer.Domain.Contracts
{
    public interface IReportingService
    {
        Task<AccountStatusReport> GetAccountStatusReport(int clientId, DateTime? startDate, DateTime? endDate);
    }
}
