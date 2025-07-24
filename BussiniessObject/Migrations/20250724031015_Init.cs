using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusiniessObject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "Users",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CitizenId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvtUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UId);
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.PId);
                    table.ForeignKey(
                        name: "FK_Proposals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PrId);
                    table.ForeignKey(
                        name: "FK_Projects_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyLines",
                columns: table => new
                {
                    SlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompletionPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    is_delete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyLines", x => x.SlId);
                    table.ForeignKey(
                        name: "FK_SurveyLines_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "PrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyPoints",
                columns: table => new
                {
                    SpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(11,8)", nullable: false),
                    altitude = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    is_delete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_date = table.Column<DateOnly>(type: "date", nullable: false),
                    survey_line_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyPoints", x => x.SpId);
                    table.ForeignKey(
                        name: "FK_SurveyPoints_SurveyLines_survey_line_id",
                        column: x => x.survey_line_id,
                        principalTable: "SurveyLines",
                        principalColumn: "SlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hydrologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_point_id = table.Column<int>(type: "int", nullable: false),
                    water_presence = table.Column<bool>(type: "bit", nullable: false),
                    water_level = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    water_flow = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    distance_to_water_source = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    water_source_features = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    surface_water_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    surface_water_level = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    surface_water_flow = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    surface_water_distance = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    surface_water_features = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hydrologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hydrologies_SurveyPoints_survey_point_id",
                        column: x => x.survey_point_id,
                        principalTable: "SurveyPoints",
                        principalColumn: "SpId",
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
                    population_density = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
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
                        principalColumn: "SpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VegetationCovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    survey_point_id = table.Column<int>(type: "int", nullable: false),
                    grass_percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    soil_percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    forest_percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    crop_percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    other = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    natural_forest_percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    flower_percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VegetationCovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VegetationCovers_SurveyPoints_survey_point_id",
                        column: x => x.survey_point_id,
                        principalTable: "SurveyPoints",
                        principalColumn: "SpId",
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
                table: "Users",
                columns: new[] { "UId", "AvtUrl", "CitizenId", "DOB", "Email", "IsMale", "Password", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { 1, "https://example.com/avatar1.jpg", "040203007094", new DateOnly(2003, 1, 1), "bda2k3@gmail.com", true, "1", "0899070745", 1, "a" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UId", "AvtUrl", "CitizenId", "DOB", "Email", "IsDelete", "IsMale", "Password", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { 2, "https://example.com/avatar2.jpg", "987654321098", new DateOnly(1995, 8, 22), "tranthib@gmail.com", true, false, "1", "0912345678", 2, "b" });

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
                table: "MeasuringDevices",
                columns: new[] { "Id", "DeviceTypeId", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 1, "GAMMA001" },
                    { 2, 2, "GAMMASPEC001" },
                    { 3, 3, "XRF001" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "RequiredDate", "user_id" },
                values: new object[,]
                {
                    { 1, "Kiểm tra thiết bị đo Gamma", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Lập kế hoạch hiệu chuẩn XRF", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "PId", "CreatedDate", "EndDate", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 1), new DateOnly(2025, 5, 1), "Proposal Alpha", 1 },
                    { 2, new DateOnly(2025, 2, 1), new DateOnly(2025, 5, 1), "Proposal Beta", 1 }
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
                table: "Projects",
                columns: new[] { "PrId", "CreatedDate", "EndDate", "Name", "ProposalId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 15), new DateOnly(2025, 5, 1), "Project A", 1 },
                    { 2, new DateOnly(2025, 2, 15), new DateOnly(2025, 5, 1), "Project B", 1 }
                });

            migrationBuilder.InsertData(
                table: "XRFInfos",
                columns: new[] { "Id", "MeasuringDeviceId", "Note" },
                values: new object[,]
                {
                    { 1, 3, "Thiết bị kiểm tra tại mỏ A" },
                    { 2, 3, "Thiết bị đang hiệu chuẩn" }
                });

            migrationBuilder.InsertData(
                table: "SurveyLines",
                columns: new[] { "SlId", "CompletionPercentage", "CreatedDate", "Name", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1, 50.0m, new DateOnly(2025, 1, 20), "Survey Line 1", 1, 0 },
                    { 2, 75.0m, new DateOnly(2025, 2, 20), "Survey Line 2", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "SurveyPoints",
                columns: new[] { "SpId", "address", "altitude", "created_date", "latitude", "longitude", "survey_line_id", "survey_name" },
                values: new object[,]
                {
                    { 1, "Hanoi, Vietnam", 10.5m, new DateOnly(2025, 1, 21), 21.0285m, 105.8542m, 1, "Survey Point Alpha" },
                    { 2, "Hanoi, Vietnam", 12.3m, new DateOnly(2025, 1, 22), 21.0245m, 105.8412m, 1, "Survey Point Beta" }
                });

            migrationBuilder.InsertData(
                table: "Hydrologies",
                columns: new[] { "Id", "distance_to_water_source", "surface_water_distance", "surface_water_features", "surface_water_flow", "surface_water_level", "surface_water_type", "survey_point_id", "water_flow", "water_level", "water_presence", "water_source_features" },
                values: new object[,]
                {
                    { 1, 50.0m, 45.0m, "Clean flowing water", 0.8m, 1.8m, "River", 1, 1.2m, 2.5m, true, "Small river nearby" },
                    { 2, 200.0m, null, null, null, null, null, 2, null, null, false, "Distant water source" }
                });

            migrationBuilder.InsertData(
                table: "LocationDescriptions",
                columns: new[] { "Id", "location_description", "infrastructure", "population_density", "residents", "survey_point_id", "survey_point_type" },
                values: new object[,]
                {
                    { 1, "Central urban area with high population density", "Good roads, electricity, water supply", 1500.50m, "Mixed residential and commercial", 1, "Urban" },
                    { 2, "Suburban area with moderate population", "Basic infrastructure available", 800.25m, "Mainly residential", 2, "Suburban" }
                });

            migrationBuilder.InsertData(
                table: "VegetationCovers",
                columns: new[] { "Id", "crop_percentage", "flower_percentage", "forest_percentage", "grass_percentage", "natural_forest_percentage", "other", "soil_percentage", "survey_point_id" },
                values: new object[,]
                {
                    { 1, 10.0m, 5.0m, 25.0m, 20.0m, 20.0m, 5.0m, 15.0m, 1 },
                    { 2, 10.0m, 5.0m, 20.0m, 30.0m, 10.0m, 5.0m, 20.0m, 2 }
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
                name: "IX_Notifications_user_id",
                table: "Notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PhoGammaInfos_MeasuringDeviceId",
                table: "PhoGammaInfos",
                column: "MeasuringDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProposalId",
                table: "Projects",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_UserId",
                table: "Proposals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_question_group_id",
                table: "question",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyLines_ProjectId",
                table: "SurveyLines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyPoints_survey_line_id",
                table: "SurveyPoints",
                column: "survey_line_id");

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
                name: "SurveyLines");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
