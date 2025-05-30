using Microsoft.EntityFrameworkCore;
using ClinicaVeterinariaApi.Models;

namespace ClinicaVeterinariaApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Pet> Pets { get; set; }
}