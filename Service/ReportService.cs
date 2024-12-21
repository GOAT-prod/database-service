using DataAccess.Intefaces;
using Models;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service;

public class ReportService(IReportRepository reportRepository) : IReportService
{
    public async Task<List<Report>> GetReport(int id) => await reportRepository.GetReport(id);
    
    public async Task<List<Report>> GetUserReport(int id) => await reportRepository.GetUserReport(id);
}