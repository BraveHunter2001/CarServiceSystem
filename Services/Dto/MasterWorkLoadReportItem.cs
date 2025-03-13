namespace Services.Dto;

public class MasterWorkLoadReportItem
{
    public string FullnameMaster { get; set; }
    public int WorkloadPercentage { get; set; }

    public MasterWorkLoadReportItem(string fullname, int percentage)
    {
        FullnameMaster = fullname;
        WorkloadPercentage = percentage;
    }
}
