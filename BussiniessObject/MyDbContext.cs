using BusinessObject.Models;
using BusiniessObject.Models;
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
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<GammaDevice> GammaDevices { get; set; }
        public DbSet<GammaCalibration> GammaCalibrations { get; set; }
        public DbSet<PhoGammaDevice> PhoGammaDevices { get; set; }
        public DbSet<XrfDevice> XrfDevices { get; set; }


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

            // User entity configuration
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

            // Seed data for User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    RoleId = 1,
                    UserName = "DucAnh",
                    Password = "01012003",
                    CitizenId = "040203007094",
                    DOB = DateOnly.FromDateTime(new DateTime(2003, 1, 1)),
                    PhoneNumber = "0899070745",
                    Email = "bda2k3@gmail.com",
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


            // Question entity configuration
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__question__3213E83F197C22A5");
                entity.ToTable("question");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AnswerText).HasColumnName("answer_text");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.QuestionText).HasColumnName("questionWriting");
                entity.HasOne(d => d.Group).WithMany(p => p.Questions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__question__group___398D8EEE");
            });

            // QuestionGroup entity configuration
            modelBuilder.Entity<QuestionGroup>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__question__3213E83F4DFF750F");
                entity.ToTable("question_group");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            

            // Seed data for QuestionGroup
            modelBuilder.Entity<QuestionGroup>().HasData(
                new QuestionGroup { Id = 1, Name = "General Knowledge" },
                new QuestionGroup { Id = 2, Name = "Technical Questions" },
                new QuestionGroup { Id = 3, Name = "Safety Procedures" }
            );

            // Seed data for Question
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    GroupId = 1,
                    QuestionText = "What is the capital city of Vietnam?",
                    AnswerText = "Hanoi"
                },
                new Question
                {
                    Id = 2,
                    GroupId = 2,
                    QuestionText = "What is the primary function of a gamma spectrometer?",
                    AnswerText = "To measure gamma radiation levels"
                },
                new Question
                {
                    Id = 3,
                    GroupId = 3,
                    QuestionText = "What is the first step in radiation safety protocol?",
                    AnswerText = "Wear appropriate protective gear"
                }
            );

            modelBuilder.Entity<GammaDevice>().HasQueryFilter(d => d.Status == "Active");
            modelBuilder.Entity<PhoGammaDevice>().HasQueryFilter(d => d.Status == "Active");
            modelBuilder.Entity<XrfDevice>().HasQueryFilter(d => d.Status == "Active");
            modelBuilder.Entity<GammaCalibration>().HasQueryFilter(c => c.GammaDevice.Status == "Active");

            // Seed data
            modelBuilder.Entity<GammaDevice>().HasData(
                new GammaDevice { Id = 1, SerialNumber = "GAM-001", Status = "Active" },
                new GammaDevice { Id = 2, SerialNumber = "GAM-002", Status = "Active" }
            );

            modelBuilder.Entity<GammaCalibration>().HasData(
                new GammaCalibration { Id = 1, GammaDeviceId = 1, RangeValue = 0.1, Coefficient = 1.5, Status = "Active" },
                new GammaCalibration { Id = 2, GammaDeviceId = 1, RangeValue = 0.2, Coefficient = 2.5, Status = "Active" },
                new GammaCalibration { Id = 3, GammaDeviceId = 2, RangeValue = 0.3, Coefficient = 3.5, Status = "Active" }
            );

            modelBuilder.Entity<PhoGammaDevice>().HasData(
                new PhoGammaDevice { Id = 1, SerialNumber = "PHO-001", K = 10.5, U = 12.3, Th = 14.2, Status = "Active" },
                new PhoGammaDevice { Id = 2, SerialNumber = "PHO-002", K = 11.5, U = 13.3, Th = 15.2, Status = "Active" }
            );

            modelBuilder.Entity<XrfDevice>().HasData(
                new XrfDevice { Id = 1, SerialNumber = "XRF-001", Note = "Initial XRF device", Status = "Active" },
                new XrfDevice { Id = 2, SerialNumber = "XRF-002", Note = "Backup device", Status = "Active" }
            );
        }
    }
}