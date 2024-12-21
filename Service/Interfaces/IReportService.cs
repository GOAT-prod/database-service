using Models;

namespace Service.Interfaces;

public interface IReportService
{
    Task<List<Report>> GetReport(int id);
    Task<List<Report>> GetUserReport(int id);
}