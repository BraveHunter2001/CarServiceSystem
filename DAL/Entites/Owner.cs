namespace DAL.Entites;

public class Owner
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; }
    public required string Phone { get; set; }
    public required string PassportSeries { get; set; }
    public required string PassportNumber { get; set; }
    public required string ResidentialAddress { get; set; }

    //relations:
    public ICollection<Automobile>? Automobiles { get; set; }
}
