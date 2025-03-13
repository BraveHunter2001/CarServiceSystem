using DAL.Entites;

namespace Services.Dto;

public class AutomobileReportItem
{
    public int AutomobileId;
    public string Brand { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public int Mileage { get; set; }
    public float EngineVolume { get; set; }

    public MasterCostReportItem[] MasterCostItems { get; set; }
    public decimal AllWorkPrice { get; set; }

    public DateTime? LastRepairWorkRecordDate { get; set; }
    public string LastMaster { get; set; }

    public AutomobileReportItem(Automobile automobile)
    {
        AutomobileId = automobile.Id;
        Brand = automobile.Brand;
        Model = automobile.Model;
        LicensePlate = automobile.LicensePlate;
        Mileage = automobile.Mileage;
        EngineVolume = automobile.EngineVolume;

        var workRecords = automobile.WorkRecords;

        MasterCostItems = workRecords?
            .GroupBy(w => w.Master)
            .Select(w =>
                new MasterCostReportItem(
                    w.Key!.Fullname,
                    w.Sum(g => g.Cost)
                )
            ).ToArray() ?? [];

        AllWorkPrice = workRecords?.Sum(w => w.Cost) ?? 0;

        var lastWorkRecord = workRecords?.OrderBy(w => w.RepairDate).Last();
        LastMaster = lastWorkRecord?.Master!.Fullname ?? string.Empty;
        LastRepairWorkRecordDate = lastWorkRecord?.RepairDate;
    }
}

public class MasterCostReportItem
{
    public string Fullname { get; set; }
    public DateTime LastWorkDate { get; set; }
    public decimal Cost { get; set; }

    public MasterCostReportItem(string fullname, decimal cost)
    {
        Fullname = fullname;
        Cost = cost;
    }
}
