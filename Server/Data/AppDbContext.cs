using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMember_server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Ride> Rides { get; set; }
    public DbSet<VehiculeModel> VehiculeModels { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().HasData(InitialData.Pizzas);
        modelBuilder.Entity<Ingredient>().HasData(InitialData.Ingredients);
    }


}
