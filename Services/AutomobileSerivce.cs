
using DAL.Repositories;
using Services.Dto;
using WebApi.Requests;

namespace Services;

public interface IAutomobileService
{
    AutomobileReportItem[] GetRepairingAutomobilesByDate(ReportFilter reportRequest);
}
internal class AutomobileSerivce(IAutomobileRepository automobileRepository) : IAutomobileService
{
    public AutomobileReportItem[] GetRepairingAutomobilesByDate(ReportFilter reportRequest)
    {
        var reportItems = automobileRepository.GetRepairingAutomobilesByDate(reportRequest)
            .Select(a => new AutomobileReportItem(a));

        var sorted = reportRequest.SortBy switch
        {
            SortBy.LastMaster => reportRequest.SortDir == SortDir.Asc
                ? reportItems.OrderBy(r => r.LastMaster)
                : reportItems.OrderByDescending(r => r.LastMaster),
            SortBy.LastRepairDate => reportRequest.SortDir == SortDir.Asc
                ? reportItems.OrderBy(r => r.LastRepairWorkRecordDate)
                : reportItems.OrderByDescending(r => r.LastRepairWorkRecordDate),
            _ => reportItems
        };

        return sorted.ToArray();
    }
}
