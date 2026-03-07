using Microsoft.EntityFrameworkCore;
using backend.src.Domain.Models;

namespace backend.src.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
    public DbSet<ImmunizationCard> Immunizations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=immunization_card.db");
    }
}
