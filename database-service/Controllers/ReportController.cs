using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace database_service.Controllers;

[ApiController]
public class ReportController(IReportService reportService) : ControllerBase
{
    [HttpGet("report")]
    public async Task<List<Report>> GetReport() => await reportService.GetReport();
}