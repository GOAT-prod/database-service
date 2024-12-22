using DataAccess.Intefaces;
using Models;
using Newtonsoft.Json;
using Repository.Interfaces;

namespace Repository;

public class ReportRepository(IPostgresContext postgresContext) : IReportRepository
{
    public async Task<List<Report>> GetReport(int id) => (await postgresContext.Select<DbReport>(Scripts.Scripts.GenerateReport, new {id})).Select(r => new Report
    {
        Date = r.Date,
        TotalPrice = r.TotalPrice,
        Items = JsonConvert.DeserializeObject<List<ReportItem>>(r.Items) ?? []
    }).ToList();
    
    public async Task<List<Report>> GetUserReport(int id) => (await postgresContext.Select<DbReport>(Scripts.Scripts.GenerateUserReport, new {id})).Select(r => new Report
    {
        Date = r.Date,
        TotalPrice = r.TotalPrice,
        Items = JsonConvert.DeserializeObject<List<ReportItem>>(r.Items) ?? []
    }).ToList();
}