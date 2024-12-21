using Models;

namespace Repository.Interfaces;

public interface IReportRepository
{
    Task<List<Report>> GetReport(int id);
    Task<List<Report>> GetUserReport(int id);
}