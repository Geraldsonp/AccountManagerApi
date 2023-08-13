using System;
using AccountManagerAPi.Dtos;
using ApplicationLayer.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace AccountManagerAPi.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportingService _reportingService;


        public ReportsController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> Get(int clientId, [FromQuery] ReportParameters parameters)
        {
            var report = await _reportingService.GetAccountStatusReport(clientId, parameters.From, parameters.To);
            return Ok(report);
        }
    }
}
