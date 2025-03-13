namespace DAL.Entites;

public class Master
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; }
    public required string Phone { get; set; }
    public int WorkExperience { get; set; }

    public string Fullname => string.IsNullOrWhiteSpace(Patronymic)
        ? string.Join(" ", Name, Surname)
        : string.Join(" ", Name, Surname, Patronymic);

    public ICollection<WorkRecord>? WorkRecords { get; set; }
}
