using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentApart.Data.Models;

namespace RentApart.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PropertyType> PropertyTypes => Set<PropertyType>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();
    public DbSet<Inquiry> Inquiries => Set<Inquiry>();
    public DbSet<Favorite> Favorites => Set<Favorite>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Favorite>()
            .HasKey(f => new { f.UserId, f.PropertyId });

        builder.Entity<Property>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        builder.Entity<Property>()
            .HasOne(p => p.Owner)
            .WithMany(u => u.Properties)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Inquiry>()
            .HasOne(i => i.Sender)
            .WithMany(u => u.Inquiries)
            .HasForeignKey(i => i.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<PropertyType>().HasData(
            new PropertyType { Id = 1, Name = "Апартамент" },
            new PropertyType { Id = 2, Name = "Къща" },
            new PropertyType { Id = 3, Name = "Офис" },
            new PropertyType { Id = 4, Name = "Парцел" });

        builder.Entity<City>().HasData(
            new City { Id = 1, Name = "София" },
            new City { Id = 2, Name = "Пловдив" },
            new City { Id = 3, Name = "Варна" },
            new City { Id = 4, Name = "Бургас" });
    }
}
