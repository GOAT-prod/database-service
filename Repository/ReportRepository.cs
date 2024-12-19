using DataAccess.Intefaces;
using Models;
using Newtonsoft.Json;
using Repository.Interfaces;

namespace Repository;

public class ReportRepository(IPostgresContext postgresContext) : IReportRepository
{
    public async Task<List<Report>> GetReport() => (await postgresContext.Select<DbReport>(Scripts.Scripts.GenerateReport)).Select(r => new Report
    {
        Date = r.Date,
        TotalPrice = r.TotalPrice,
        Items = JsonConvert.DeserializeObject<List<ReportItem>>(r.Items) ?? []
    }).ToList();
}