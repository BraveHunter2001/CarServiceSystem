using Services.Dto;

namespace WebApi.ViewModels;

public class ReportViewModel
{
    public AutomobileReportItem[] Autos { get; set; }
    public MasterWorkLoadReportItem[] MastersWorkLoads { get; set; }

    public ReportViewModel(AutomobileReportItem[] autos, MasterWorkLoadReportItem[] mastersWorkLoads)
    {
        Autos = autos;
        MastersWorkLoads = mastersWorkLoads;
    }
}
