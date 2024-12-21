using Microsoft.AspNetCore.Mvc;
using Models;
using Service.Interfaces;

namespace database_service.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController(IReportService reportService) : ControllerBase
{
    [HttpGet("factory/{clientId}")]
    public async Task<List<Report>> GetReport(int clientId) => await reportService.GetReport(clientId);
    
    [HttpGet("user/{userId}")]
    public async Task<List<Report>> GetUserReport(int userId) => await reportService.GetUserReport(userId);
}