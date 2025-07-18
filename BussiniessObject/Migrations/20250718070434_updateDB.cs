using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusiniessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "question_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__question__3213E83F4DFF750F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(10,8)", precision: 10, scale: 8, nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(11,8)", precision: 8, scale: 2, nullable: false),
                    altitude = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    surveyor_id = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvtUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuringDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuringDevices_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_id = table.Column<int>(type: "int", nullable: false),
                    questionWriting = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    answer_text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__question__3213E83F197C22A5", x => x.id);
                    table.ForeignKey(
                        name: "FK__question__group___398D8EEE",
                        column: x => x.group_id,
                        principalTable: "question_group",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hydrologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_point_id = table.Column<int>(type: "int", nullable: false),
                    water_presence = table.Column<bool>(type: "bit", nullable: false),
                    water_level = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    water_flow = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    distance_to_water_source = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    water_source_features = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    surface_water_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    surface_water_level = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    surface_water_flow = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    surface_water_distance = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    surface_water_features = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hydrologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hydrologies_SurveyPoints_survey_point_id",
                        column: x => x.survey_point_id,
                        principalTable: "SurveyPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_point_id = table.Column<int>(type: "int", nullable: false),
                    survey_point_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    population_density = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    location_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    infrastructure = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    residents = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationDescriptions_SurveyPoints_survey_point_id",
                        column: x => x.survey_point_id,
                        principalTable: "SurveyPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VegetationCovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_point_id = table.Column<int>(type: "int", nullable: false),
                    grass_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    soil_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    forest_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    crop_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    other = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    natural_forest_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    flower_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VegetationCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VegetationCovers_SurveyPoints_survey_point_id",
                        column: x => x.survey_point_id,
                        principalTable: "SurveyPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GammaCalibrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Khoang = table.Column<double>(type: "float", nullable: false),
                    HeSoChuanMay = table.Column<double>(type: "float", nullable: false),
                    MeasuringDeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GammaCalibrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GammaCalibrations_MeasuringDevices_MeasuringDeviceId",
                        column: x => x.MeasuringDeviceId,
                        principalTable: "MeasuringDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoGammaInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasuringDeviceId = table.Column<int>(type: "int", nullable: false),
                    K = table.Column<double>(type: "float", nullable: false),
                    U = table.Column<double>(type: "float", nullable: false),
                    Th = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoGammaInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoGammaInfos_MeasuringDevices_MeasuringDeviceId",
                        column: x => x.MeasuringDeviceId,
                        principalTable: "MeasuringDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XRFInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasuringDeviceId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XRFInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XRFInfos_MeasuringDevices_MeasuringDeviceId",
                        column: x => x.MeasuringDeviceId,
                        principalTable: "MeasuringDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeviceTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Gamma" },
                    { 2, "Gamma Spectrum" },
                    { 3, "XRF" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "RequiredDate" },
                values: new object[,]
                {
                    { 1, "Kiểm tra thiết bị đo Gamma", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Lập kế hoạch hiệu chuẩn XRF", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SurveyPoints",
                columns: new[] { "Id", "address", "altitude", "is_active", "latitude", "longitude", "survey_name", "surveyor_id" },
                values: new object[,]
                {
                    { 1, "Điểm khảo sát ban đầu tại khu vực phía Bắc", 68.023m, true, 21.0285m, 105.8542m, "Điểm khảo sát khu vực A", 1 },
                    { 2, "Điểm khảo sát gần sông Hồng", 68.023m, true, 21.0195m, 105.8445m, "Điểm khảo sát khu vực B", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvtUrl", "CitizenId", "DOB", "Email", "IsDelete", "IsMale", "Password", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, "https://example.com/avatar1.jpg", "040203007094", new DateOnly(2003, 1, 1), "bda2k3@gmail.com", false, true, "01012003", "0899070745", 1, "DucAnh" },
                    { 2, "https://example.com/avatar2.jpg", "987654321098", new DateOnly(1995, 8, 22), "tranthib@gmail.com", true, false, "12345678", "0912345678", 2, "TranThiB" },
                    { 3, "https://example.com/avatar3.jpg", "456789123456", new DateOnly(1988, 3, 10), "levanc@gmail.com", false, true, "12345678", "0923456789", 1, "LeVanC" },
                    { 4, "https://example.com/avatar4.jpg", "789123456789", new DateOnly(1992, 11, 30), "phamthid@gmail.com", true, false, "12345678", "0934567890", 3, "PhamThiD" },
                    { 5, "https://example.com/avatar5.jpg", "321654987123", new DateOnly(1993, 7, 25), "hoangvane@gmail.com", false, true, "12345678", "0945678901", 2, "HoangVanE" }
                });

            migrationBuilder.InsertData(
                table: "question_group",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "General Knowledge" },
                    { 2, "Technical Questions" },
                    { 3, "Safety Procedures" }
                });

            migrationBuilder.InsertData(
                table: "Hydrologies",
                columns: new[] { "Id", "distance_to_water_source", "surface_water_distance", "surface_water_features", "surface_water_flow", "surface_water_level", "surface_water_type", "survey_point_id", "water_flow", "water_level", "water_presence", "water_source_features" },
                values: new object[,]
                {
                    { 1, 150.0m, 200.0m, "Có thể sử dụng cho tưới tiêu", 1.2m, 2.0m, "Sông tự nhiên", 1, 0.8m, 1.5m, true, "Sông Hồng, nước chảy theo mùa" },
                    { 2, 50.0m, 30.0m, "Chủ yếu phục vụ cảnh quan", 0.0m, 1.0m, "Hồ nhân tạo", 2, 0.0m, 0.5m, true, "Hồ Hoàn Kiếm, nước tĩnh" }
                });

            migrationBuilder.InsertData(
                table: "LocationDescriptions",
                columns: new[] { "Id", "location_description", "infrastructure", "population_density", "residents", "survey_point_id", "survey_point_type" },
                values: new object[,]
                {
                    { 1, "Khu vực đồng bằng sông Hồng, gần bờ sông", "Có đường liên thôn, điện lưới quốc gia", 850.5m, "Nông dân địa phương", 1, "Nông nghiệp" },
                    { 2, "Khu vực trung tâm thành phố, gần hồ", "Hạ tầng hoàn chỉnh, giao thông thuận lợi", 2500.0m, "Cư dân thành phố", 2, "Đô thị" }
                });

            migrationBuilder.InsertData(
                table: "MeasuringDevices",
                columns: new[] { "Id", "DeviceTypeId", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 1, "GAMMA001" },
                    { 2, 2, "GAMMASPEC001" },
                    { 3, 3, "XRF001" }
                });

            migrationBuilder.InsertData(
                table: "VegetationCovers",
                columns: new[] { "Id", "crop_percentage", "flower_percentage", "forest_percentage", "grass_percentage", "natural_forest_percentage", "other", "soil_percentage", "survey_point_id" },
                values: new object[,]
                {
                    { 1, 45.0m, 1.0m, 10.0m, 25.5m, 3.5m, "Đất xây dựng, đường xá", 15.0m, 1 },
                    { 2, 5.0m, 20.0m, 20.0m, 35.0m, 15.0m, "Công trình đô thị, sân vườn", 5.0m, 2 }
                });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "id", "answer_text", "group_id", "questionWriting" },
                values: new object[,]
                {
                    { 1, "Hanoi", 1, "What is the capital city of Vietnam?" },
                    { 2, "To measure gamma radiation levels", 2, "What is the primary function of a gamma spectrometer?" },
                    { 3, "Wear appropriate protective gear", 3, "What is the first step in radiation safety protocol?" }
                });

            migrationBuilder.InsertData(
                table: "GammaCalibrations",
                columns: new[] { "Id", "HeSoChuanMay", "Khoang", "MeasuringDeviceId" },
                values: new object[,]
                {
                    { 1, 0.97999999999999998, 50.0, 1 },
                    { 2, 1.05, 14.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "PhoGammaInfos",
                columns: new[] { "Id", "K", "MeasuringDeviceId", "Th", "U" },
                values: new object[,]
                {
                    { 1, 12.5, 2, 3.1000000000000001, 5.2000000000000002 },
                    { 2, 14.0, 2, 3.7999999999999998, 4.9000000000000004 }
                });

            migrationBuilder.InsertData(
                table: "XRFInfos",
                columns: new[] { "Id", "MeasuringDeviceId", "Note" },
                values: new object[,]
                {
                    { 1, 3, "Thiết bị kiểm tra tại mỏ A" },
                    { 2, 3, "Thiết bị đang hiệu chuẩn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GammaCalibrations_MeasuringDeviceId",
                table: "GammaCalibrations",
                column: "MeasuringDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Hydrologies_survey_point_id",
                table: "Hydrologies",
                column: "survey_point_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationDescriptions_survey_point_id",
                table: "LocationDescriptions",
                column: "survey_point_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringDevices_DeviceTypeId",
                table: "MeasuringDevices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoGammaInfos_MeasuringDeviceId",
                table: "PhoGammaInfos",
                column: "MeasuringDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_question_group_id",
                table: "question",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CitizenId",
                table: "Users",
                column: "CitizenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VegetationCovers_survey_point_id",
                table: "VegetationCovers",
                column: "survey_point_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_XRFInfos_MeasuringDeviceId",
                table: "XRFInfos",
                column: "MeasuringDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GammaCalibrations");

            migrationBuilder.DropTable(
                name: "Hydrologies");

            migrationBuilder.DropTable(
                name: "LocationDescriptions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PhoGammaInfos");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VegetationCovers");

            migrationBuilder.DropTable(
                name: "XRFInfos");

            migrationBuilder.DropTable(
                name: "question_group");

            migrationBuilder.DropTable(
                name: "SurveyPoints");

            migrationBuilder.DropTable(
                name: "MeasuringDevices");

            migrationBuilder.DropTable(
                name: "DeviceTypes");
        }
    }
}
