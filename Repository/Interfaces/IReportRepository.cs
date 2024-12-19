using Models;

namespace Repository.Interfaces;

public interface IReportRepository
{
    Task<List<Report>> GetReport();
}