using DataAccess.Intefaces;
using Models;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service;

public class ReportService(IReportRepository reportRepository) : IReportService
{
    public async Task<List<Report>> GetReport() => await reportRepository.GetReport();
}