using Models;

namespace Service.Interfaces;

public interface IReportService
{
    Task<List<Report>> GetReport();
}