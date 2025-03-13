namespace DAL.Entites;

public class Automobile
{
    public int Id { get; set; }

    public required string Brand { get; set; }
    public required string Model { get; set; }
    public required string LicensePlate { get; set; }
    public int Mileage { get; set; }
    public float EngineVolume { get; set; }

    //relations:
    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }
    public ICollection<WorkRecord>? WorkRecords { get; set; }
}
