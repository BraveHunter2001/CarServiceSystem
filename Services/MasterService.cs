
using DAL.Repositories;
using Services.Dto;

namespace Services;

public interface IMasterService
{
    MasterWorkLoadReportItem[] GetPercentageOfMasterWorkload(DateTime startDate, DateTime endDate);
}
internal class MasterService(IMasterRepository masterRepository) : IMasterService
{
    public MasterWorkLoadReportItem[] GetPercentageOfMasterWorkload(DateTime startDate, DateTime endDate)
    {
        var reportItems = masterRepository.GetPercentageOfMasterWorkload(startDate, endDate)
           .Select(x => new MasterWorkLoadReportItem(x.Key.Fullname, x.Value))
           .ToArray();

        return reportItems;
    }
       
}
