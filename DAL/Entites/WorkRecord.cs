namespace DAL.Entites;

public class WorkRecord
{
    public int Id { get; set; }
    public required string Malfunction { get; set; }
    public decimal Cost { get; set; }
    public DateTime RepairDate { get; set; }
    public DateTime? CompletionDate { get; set; }

    // relations:
    public int AutomobileId { get; set; }
    public Automobile? Automobile { get; set; }

    public int MasterId { get; set; }
    public Master? Master { get; set; }
}
