using DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class CarServiceSystemContext : DbContext
{
    public CarServiceSystemContext(DbContextOptions<CarServiceSystemContext> options) : base(options)
    {
    }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<Automobile> Automobiles { get; set; }
    public DbSet<WorkRecord> WorkRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>()
            .HasMany(o => o.Automobiles)
            .WithOne(a => a.Owner)
            .HasForeignKey(a => a.OwnerId);

        modelBuilder.Entity<Automobile>()
           .HasMany(a => a.WorkRecords)
           .WithOne(wr => wr.Automobile)
           .HasForeignKey(wr => wr.AutomobileId);

        modelBuilder.Entity<Master>()
          .HasMany(m => m.WorkRecords)
          .WithOne(wr => wr.Master)
          .HasForeignKey(wr => wr.MasterId);

        base.OnModelCreating(modelBuilder);
    }
}
