using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarMember_server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Ride> Rides { get; set; }
    public DbSet<VehiculeModel> VehiculeModels { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<RideUser> RideUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany(e => e.ReviewedReviews)
        .WithOne(e => e.ReviewedUser)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
        .HasMany(e => e.AuthorReviews)
        .WithOne(e => e.AuthorUser);


        modelBuilder.Entity<RideUser>()
            .HasOne(e => e.User)
            .WithMany(u => u.RideUsers)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RideUser>()
            .HasOne(e => e.Ride)
            .WithMany(u => u.RideUsers)
            .OnDelete(DeleteBehavior.Restrict);


        // Initial Data des véhicules de Base
        modelBuilder.Entity<VehiculeModel>().HasData(InitialData.VehiculeModels);

        // Initial Data de test pré-remplis
        modelBuilder.Entity<User>().HasData(InitialTestData.Users);
        modelBuilder.Entity<Ride>().HasData(InitialTestData.Rides);
        modelBuilder.Entity<Review>().HasData(InitialTestData.Reviews);
        //modelBuilder.Entity<VehiculeModel>().HasData(InitialTestData.VehiculeModels);
        modelBuilder.Entity<RideUser>().HasData(InitialTestData.RideUsers);


    }


}
