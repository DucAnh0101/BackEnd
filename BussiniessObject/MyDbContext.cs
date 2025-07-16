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
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<MeasuringDevice> MeasuringDevices { get; set; }
        public DbSet<GammaInfo> GammaInfos { get; set; }
        public DbSet<GammaCalibration> GammaCalibrations { get; set; }
        public DbSet<PhoGammaInfo> PhoGammaInfos { get; set; }
        public DbSet<XRFInfo> XRFInfos { get; set; }

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

            // Relationships for MeasuringDevice
            modelBuilder.Entity<GammaInfo>()
                .HasOne(g => g.MeasuringDevice)
                .WithOne(d => d.GammaInfo)
                .HasForeignKey<GammaInfo>(g => g.MeasuringDeviceId);

            modelBuilder.Entity<PhoGammaInfo>()
                .HasOne(p => p.MeasuringDevice)
                .WithOne(d => d.PhoGammaInfo)
                .HasForeignKey<PhoGammaInfo>(p => p.MeasuringDeviceId);

            modelBuilder.Entity<XRFInfo>()
                .HasOne(x => x.MeasuringDevice)
                .WithOne(d => d.XRFInfo)
                .HasForeignKey<XRFInfo>(x => x.MeasuringDeviceId);

            modelBuilder.Entity<GammaCalibration>()
                .HasOne(c => c.GammaInfo)
                .WithMany(g => g.Calibrations)
                .HasForeignKey(c => c.GammaInfoId);

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

            // DeviceType entity configuration
            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("DeviceType");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // MeasuringDevice entity configuration
            modelBuilder.Entity<MeasuringDevice>(entity =>
            {
                entity.ToTable("MeasuringDevice");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.DeviceTypeId).HasColumnName("device_type_id");
                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.MeasuringDevices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MeasuringDevice_DeviceType");
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

            // Seed data for DeviceType
            modelBuilder.Entity<DeviceType>().HasData(
                new DeviceType { Id = 1, TypeName = "Gamma Spectrometer" },
                new DeviceType { Id = 2, TypeName = "XRF Analyzer" },
                new DeviceType { Id = 3, TypeName = "PhoGamma Device" }
            );

            // Seed data for MeasuringDevice
            modelBuilder.Entity<MeasuringDevice>().HasData(
                new MeasuringDevice { Id = 1, SerialNumber = "GAMMA-001", DeviceTypeId = 1 },
                new MeasuringDevice { Id = 2, SerialNumber = "XRF-002", DeviceTypeId = 2 },
                new MeasuringDevice { Id = 3, SerialNumber = "PHO-003", DeviceTypeId = 3 }
            );

            // Seed data for GammaInfo
            modelBuilder.Entity<GammaInfo>().HasData(
                new GammaInfo { Id = 1, MeasuringDeviceId = 1 },
                new GammaInfo { Id = 2, MeasuringDeviceId = 2 },
                new GammaInfo { Id = 3, MeasuringDeviceId = 3 }
            );

            // Seed data for GammaCalibration
            modelBuilder.Entity<GammaCalibration>().HasData(
                new GammaCalibration
                {
                    Id = 1,
                    GammaInfoId = 1,
                    Khoang = "0-100 keV",
                    HeSoChuanMay = "1.25"
                },
                new GammaCalibration
                {
                    Id = 2,
                    GammaInfoId = 1,
                    Khoang = "100-200 keV",
                    HeSoChuanMay = "1.30"
                },
                new GammaCalibration
                {
                    Id = 3,
                    GammaInfoId = 2,
                    Khoang = "0-150 keV",
                    HeSoChuanMay = "1.20"
                }
            );

            // Seed data for PhoGammaInfo
            modelBuilder.Entity<PhoGammaInfo>().HasData(
                new PhoGammaInfo
                {
                    Id = 1,
                    MeasuringDeviceId = 1,
                    K = 0.123,
                    U = 0.456,
                    Th = 0.789
                },
                new PhoGammaInfo
                {
                    Id = 2,
                    MeasuringDeviceId = 2,
                    K = 0.234,
                    U = 0.567,
                    Th = 0.890
                },
                new PhoGammaInfo
                {
                    Id = 3,
                    MeasuringDeviceId = 3,
                    K = 0.345,
                    U = 0.678,
                    Th = 0.901
                }
            );

            // Seed data for XRFInfo
            modelBuilder.Entity<XRFInfo>().HasData(
                new XRFInfo
                {
                    Id = 1,
                    MeasuringDeviceId = 1,
                    Note = "Calibrated for soil analysis"
                },
                new XRFInfo
                {
                    Id = 2,
                    MeasuringDeviceId = 2,
                    Note = "Used for metal detection"
                },
                new XRFInfo
                {
                    Id = 3,
                    MeasuringDeviceId = 3,
                    Note = "General purpose XRF"
                }
            );
        }
    }
}