using System.Reflection.Emit;
using System.Reflection.Metadata;
using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
        modelBuilder.Entity<VehiculeModel>()
        .HasMany(e => e.Users)
        .WithOne(e => e.VehiculeModel)
        .HasForeignKey(e => e.IdVehiculeModel);

        modelBuilder.Entity<User>()
        .HasMany(e => e.Reviews)
        .WithOne(e => e.ReviewedUser);

        modelBuilder.Entity<Ride>()
        .HasMany(e => e.Users)
        .WithMany(e => e.Rides);




        //modelBuilder.Entity<User>().HasData(InitialData.Users);
        //modelBuilder.Entity<Ride>().HasData(InitialData.Rides);
        //modelBuilder.Entity<VehiculeModel>().HasData(InitialData.VehiculeModels);
        //modelBuilder.Entity<Review>().HasData(InitialData.Reviews);

    }


}
