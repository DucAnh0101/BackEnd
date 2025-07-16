using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public MyDbContext()
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.HasIndex(e => e.CitizenId).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.RoleId)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.CitizenId)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.AvtUrl)
                    .HasMaxLength(1000);

                entity.Property(e => e.IsDelete)
                    .IsRequired();

                entity.Property(e => e.IsMale)
                    .IsRequired();
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    RoleId = 1,
                    UserName = "NguyenVanA",
                    Password = "12345678",
                    CitizenId = "123456789012",
                    DOB = DateOnly.FromDateTime(new DateTime(1990, 5, 15)),
                    PhoneNumber = "0901234567",
                    Email = "nguyenvana@gmail.com",
                    AvtUrl = "https://example.com/avatar1.jpg",
                    IsDelete = false,
                    IsMale = true
                },
                new User
                {
                    Id = 2,
                    RoleId = 2,
                    UserName = "TranThiB",
                    Password = "12345678",
                    CitizenId = "987654321098",
                    DOB = DateOnly.FromDateTime(new DateTime(1995, 8, 22)),
                    PhoneNumber = "0912345678",
                    Email = "tranthib@gmail.com",
                    AvtUrl = "https://example.com/avatar2.jpg",
                    IsDelete = true,
                    IsMale = false
                },
                new User
                {
                    Id = 3,
                    RoleId = 1,
                    UserName = "LeVanC",
                    Password = "12345678",
                    CitizenId = "456789123456",
                    DOB = DateOnly.FromDateTime(new DateTime(1988, 3, 10)),
                    PhoneNumber = "0923456789",
                    Email = "levanc@gmail.com",
                    AvtUrl = "https://example.com/avatar3.jpg",
                    IsDelete = false,
                    IsMale = true
                },
                new User
                {
                    Id = 4,
                    RoleId = 3,
                    UserName = "PhamThiD",
                    Password = "12345678",
                    CitizenId = "789123456789",
                    DOB = DateOnly.FromDateTime(new DateTime(1992, 11, 30)),
                    PhoneNumber = "0934567890",
                    Email = "phamthid@gmail.com",
                    AvtUrl = "https://example.com/avatar4.jpg",
                    IsDelete = true,
                    IsMale = false
                },
                new User
                {
                    Id = 5,
                    RoleId = 2,
                    UserName = "HoangVanE",
                    Password = "12345678",
                    CitizenId = "321654987123",
                    DOB = DateOnly.FromDateTime(new DateTime(1993, 7, 25)),
                    PhoneNumber = "0945678901",
                    Email = "hoangvane@gmail.com",
                    AvtUrl = "https://example.com/avatar5.jpg",
                    IsDelete = false,
                    IsMale = true
                }
            );
        }
    }
}