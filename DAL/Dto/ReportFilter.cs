namespace WebApi.Requests;

public class ReportFilter
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public SortBy SortBy { get; set; }
    public SortDir SortDir { get; set; }
}

public enum SortBy
{
    Brand,
    LastMaster,
    LastRepairDate
}

public enum SortDir
{
    Asc,
    Dsc,
}