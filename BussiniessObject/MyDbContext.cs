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

        // Existing DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<MeasuringDevice> MeasuringDevices { get; set; }
        public DbSet<GammaCalibration> GammaCalibrations { get; set; }
        public DbSet<PhoGammaInfo> PhoGammaInfos { get; set; }
        public DbSet<XRFInfo> XRFInfos { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        // New DbSets for Survey System
        public DbSet<SurveyPoint> SurveyPoints { get; set; }
        public DbSet<LocationDescription> LocationDescriptions { get; set; }
        public DbSet<VegetationCover> VegetationCovers { get; set; }
        public DbSet<Hydrology> Hydrologies { get; set; }

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
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TypeName).HasMaxLength(100).IsRequired();
            });

            // MeasuringDevice entity configuration
            modelBuilder.Entity<MeasuringDevice>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SerialNumber).IsRequired().HasMaxLength(100);

                entity.HasOne(d => d.DeviceType)
                    .WithMany(dt => dt.MeasuringDevices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // GammaCalibration entity configuration
            modelBuilder.Entity<GammaCalibration>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Khoang);
                entity.Property(e => e.HeSoChuanMay).IsRequired();

                entity.HasOne(g => g.MeasuringDevice)
                    .WithMany(d => d.GammaCalibrations)
                    .HasForeignKey(g => g.MeasuringDeviceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // PhoGammaInfo entity configuration
            modelBuilder.Entity<PhoGammaInfo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(p => p.MeasuringDevice)
                    .WithMany(d => d.PhoGammaInfos)
                    .HasForeignKey(p => p.MeasuringDeviceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // XRFInfo entity configuration
            modelBuilder.Entity<XRFInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Note).HasMaxLength(1000);

                entity.HasOne(x => x.MeasuringDevice)
                    .WithMany(d => d.XRFInfos)
                    .HasForeignKey(x => x.MeasuringDeviceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Notification entity configuration
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.RequiredDate)
                      .IsRequired();
            });

            // SurveyPoint entity configuration
            modelBuilder.Entity<SurveyPoint>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SurveyName)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(10,8)")
                    .IsRequired();

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(11,8)")
                    .IsRequired();

                entity.Property(e => e.Altitude)
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000);

                entity.Property(e => e.SurveyorId)
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                // Configure relationships
                entity.HasOne(s => s.LocationDescription)
                    .WithOne(l => l.SurveyPoint)
                    .HasForeignKey<LocationDescription>(l => l.SurveyPointId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.VegetationCover)
                    .WithOne(v => v.SurveyPoint)
                    .HasForeignKey<VegetationCover>(v => v.SurveyPointId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Hydrology)
                    .WithOne(h => h.SurveyPoint)
                    .HasForeignKey<Hydrology>(h => h.SurveyPointId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // LocationDescription entity configuration
            modelBuilder.Entity<LocationDescription>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.SurveyPointType)
                    .HasMaxLength(100);

                entity.Property(e => e.PopulationDensity)
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                entity.Property(e => e.Infrastructure)
                    .HasMaxLength(500);

                entity.Property(e => e.Residents)
                    .HasMaxLength(100);
            });

            // VegetationCover entity configuration
            modelBuilder.Entity<VegetationCover>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.GrassPercentage)
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.SoilPercentage)
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.ForestPercentage)
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.CropPercentage)
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Other)
                    .HasMaxLength(200);

                entity.Property(e => e.NaturalForestPercentage)
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.FlowerPercentage)
                    .HasColumnType("decimal(5,2)");
            });

            // Hydrology entity configuration
            modelBuilder.Entity<Hydrology>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.WaterPresence)
                    .IsRequired();

                entity.Property(e => e.WaterLevel)
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.WaterFlow)
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.DistanceToWaterSource)
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.WaterSourceFeatures)
                    .HasMaxLength(500);

                entity.Property(e => e.SurfaceWaterType)
                    .HasMaxLength(100);

                entity.Property(e => e.SurfaceWaterLevel)
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.SurfaceWaterFlow)
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.SurfaceWaterDistance)
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.SurfaceWaterFeatures)
                    .HasMaxLength(500);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed User data
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

            // Seed QuestionGroup data
            modelBuilder.Entity<QuestionGroup>().HasData(
                new QuestionGroup { Id = 1, Name = "General Knowledge" },
                new QuestionGroup { Id = 2, Name = "Technical Questions" },
                new QuestionGroup { Id = 3, Name = "Safety Procedures" }
            );

            // Seed Question data
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

            // Seed DeviceType data
            modelBuilder.Entity<DeviceType>().HasData(
                new DeviceType { Id = 1, TypeName = "Gamma" },
                new DeviceType { Id = 2, TypeName = "Gamma Spectrum" },
                new DeviceType { Id = 3, TypeName = "XRF" }
            );

            // Seed MeasuringDevice data
            modelBuilder.Entity<MeasuringDevice>().HasData(
                new MeasuringDevice { Id = 1, SerialNumber = "GAMMA001", DeviceTypeId = 1 },
                new MeasuringDevice { Id = 2, SerialNumber = "GAMMASPEC001", DeviceTypeId = 2 },
                new MeasuringDevice { Id = 3, SerialNumber = "XRF001", DeviceTypeId = 3 }
            );

            // Seed GammaCalibration data
            modelBuilder.Entity<GammaCalibration>().HasData(
                new GammaCalibration { Id = 1, Khoang = 50, HeSoChuanMay = 0.98, MeasuringDeviceId = 1 },
                new GammaCalibration { Id = 2, Khoang = 14, HeSoChuanMay = 1.05, MeasuringDeviceId = 1 }
            );

            // Seed PhoGammaInfo data
            modelBuilder.Entity<PhoGammaInfo>().HasData(
                new PhoGammaInfo { Id = 1, MeasuringDeviceId = 2, K = 12.5, U = 5.2, Th = 3.1 },
                new PhoGammaInfo { Id = 2, MeasuringDeviceId = 2, K = 14.0, U = 4.9, Th = 3.8 }
            );

            // Seed XRFInfo data
            modelBuilder.Entity<XRFInfo>().HasData(
                new XRFInfo { Id = 1, MeasuringDeviceId = 3, Note = "Thiết bị kiểm tra tại mỏ A" },
                new XRFInfo { Id = 2, MeasuringDeviceId = 3, Note = "Thiết bị đang hiệu chuẩn" }
            );

            // Seed Notification data
            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, Content = "Kiểm tra thiết bị đo Gamma", RequiredDate = new DateTime(2025, 8, 1) },
                new Notification { Id = 2, Content = "Lập kế hoạch hiệu chuẩn XRF", RequiredDate = new DateTime(2025, 8, 15) }
            );

            // Seed SurveyPoint data
            modelBuilder.Entity<SurveyPoint>().HasData(
                new SurveyPoint
                {
                    Id = 1,
                    SurveyName = "Survey Point Alpha",
                    Latitude = 21.0285m,
                    Longitude = 105.8542m,
                    Altitude = 10.5m,
                    Address = "Hanoi, Vietnam",
                    SurveyorId = 1,
                    IsActive = true
                },
                new SurveyPoint
                {
                    Id = 2,
                    SurveyName = "Survey Point Beta",
                    Latitude = 21.0245m,
                    Longitude = 105.8412m,
                    Altitude = 12.3m,
                    Address = "Hanoi, Vietnam",
                    SurveyorId = 2,
                    IsActive = true
                }
            );

            // Seed LocationDescription data
            modelBuilder.Entity<LocationDescription>().HasData(
                new LocationDescription
                {
                    Id = 1,
                    SurveyPointId = 1,
                    SurveyPointType = "Urban",
                    PopulationDensity = 1500.50m,
                    Description = "Central urban area with high population density",
                    Infrastructure = "Good roads, electricity, water supply",
                    Residents = "Mixed residential and commercial"
                },
                new LocationDescription
                {
                    Id = 2,
                    SurveyPointId = 2,
                    SurveyPointType = "Suburban",
                    PopulationDensity = 800.25m,
                    Description = "Suburban area with moderate population",
                    Infrastructure = "Basic infrastructure available",
                    Residents = "Mainly residential"
                }
            );

            // Seed VegetationCover data
            modelBuilder.Entity<VegetationCover>().HasData(
                new VegetationCover
                {
                    Id = 1,
                    SurveyPointId = 1,
                    GrassPercentage = 25.5m,
                    SoilPercentage = 15.2m,
                    ForestPercentage = 35.8m,
                    CropPercentage = 10.5m,
                    Other = "Urban structures",
                    NaturalForestPercentage = 30.0m,
                    FlowerPercentage = 5.0m
                },
                new VegetationCover
                {
                    Id = 2,
                    SurveyPointId = 2,
                    GrassPercentage = 40.0m,
                    SoilPercentage = 20.0m,
                    ForestPercentage = 25.0m,
                    CropPercentage = 15.0m,
                    Other = "Small buildings",
                    NaturalForestPercentage = 20.0m,
                    FlowerPercentage = 8.0m
                }
            );

            // Seed Hydrology data
            modelBuilder.Entity<Hydrology>().HasData(
                new Hydrology
                {
                    Id = 1,
                    SurveyPointId = 1,
                    WaterPresence = true,
                    WaterLevel = 2.5m,
                    WaterFlow = 1.2m,
                    DistanceToWaterSource = 50.0m,
                    WaterSourceFeatures = "Small river nearby",
                    SurfaceWaterType = "River",
                    SurfaceWaterLevel = 1.8m,
                    SurfaceWaterFlow = 0.8m,
                    SurfaceWaterDistance = 45.0m,
                    SurfaceWaterFeatures = "Clean flowing water"
                },
                new Hydrology
                {
                    Id = 2,
                    SurveyPointId = 2,
                    WaterPresence = false,
                    WaterLevel = null,
                    WaterFlow = null,
                    DistanceToWaterSource = 200.0m,
                    WaterSourceFeatures = "Distant water source",
                    SurfaceWaterType = null,
                    SurfaceWaterLevel = null,
                    SurfaceWaterFlow = null,
                    SurfaceWaterDistance = null,
                    SurfaceWaterFeatures = null
                }
            );
        }
    }
}