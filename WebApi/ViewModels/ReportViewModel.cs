using Services.Dto;

namespace WebApi.ViewModels;

public class ReportViewModel
{
    AutomobileReportItem[] Autos { get; set; }
    MasterWorkLoadReportItem[] MastersWorkLoads { get; set; }

    public ReportViewModel(AutomobileReportItem[] autos, MasterWorkLoadReportItem[] mastersWorkLoads)
    {
        Autos = autos;
        MastersWorkLoads = mastersWorkLoads;
    }
}
