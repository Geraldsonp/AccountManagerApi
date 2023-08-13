using System;
using ApplicationLayer.Domain.Reports;


namespace ApplicationLayer.Domain.Contracts
{
    public interface IReportingService
    {
        Task<IEnumerable<AccountStatusReport>> GetAccountStatusReport(int clientId, DateTime? startDate, DateTime? endDate);
    }
}
