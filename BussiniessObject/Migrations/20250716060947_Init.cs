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
                name: "DeviceType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.id);
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
                name: "MeasuringDevice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serial_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    device_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringDevice", x => x.id);
                    table.ForeignKey(
                        name: "FK_MeasuringDevice_DeviceType",
                        column: x => x.device_type_id,
                        principalTable: "DeviceType",
                        principalColumn: "id",
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
                name: "GammaInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasuringDeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GammaInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GammaInfos_MeasuringDevice_MeasuringDeviceId",
                        column: x => x.MeasuringDeviceId,
                        principalTable: "MeasuringDevice",
                        principalColumn: "id",
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
                        name: "FK_PhoGammaInfos_MeasuringDevice_MeasuringDeviceId",
                        column: x => x.MeasuringDeviceId,
                        principalTable: "MeasuringDevice",
                        principalColumn: "id",
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
                        name: "FK_XRFInfos_MeasuringDevice_MeasuringDeviceId",
                        column: x => x.MeasuringDeviceId,
                        principalTable: "MeasuringDevice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GammaCalibrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Khoang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeSoChuanMay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GammaInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GammaCalibrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GammaCalibrations_GammaInfos_GammaInfoId",
                        column: x => x.GammaInfoId,
                        principalTable: "GammaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeviceType",
                columns: new[] { "id", "type_name" },
                values: new object[,]
                {
                    { 1, "Gamma Spectrometer" },
                    { 2, "XRF Analyzer" },
                    { 3, "PhoGamma Device" }
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
                table: "MeasuringDevice",
                columns: new[] { "id", "device_type_id", "serial_number" },
                values: new object[,]
                {
                    { 1, 1, "GAMMA-001" },
                    { 2, 2, "XRF-002" },
                    { 3, 3, "PHO-003" }
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
                table: "GammaInfos",
                columns: new[] { "Id", "MeasuringDeviceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "PhoGammaInfos",
                columns: new[] { "Id", "K", "MeasuringDeviceId", "Th", "U" },
                values: new object[,]
                {
                    { 1, 0.123, 1, 0.78900000000000003, 0.45600000000000002 },
                    { 2, 0.23400000000000001, 2, 0.89000000000000001, 0.56699999999999995 },
                    { 3, 0.34499999999999997, 3, 0.90100000000000002, 0.67800000000000005 }
                });

            migrationBuilder.InsertData(
                table: "XRFInfos",
                columns: new[] { "Id", "MeasuringDeviceId", "Note" },
                values: new object[,]
                {
                    { 1, 1, "Calibrated for soil analysis" },
                    { 2, 2, "Used for metal detection" },
                    { 3, 3, "General purpose XRF" }
                });

            migrationBuilder.InsertData(
                table: "GammaCalibrations",
                columns: new[] { "Id", "GammaInfoId", "HeSoChuanMay", "Khoang" },
                values: new object[,]
                {
                    { 1, 1, "1.25", "0-100 keV" },
                    { 2, 1, "1.30", "100-200 keV" },
                    { 3, 2, "1.20", "0-150 keV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GammaCalibrations_GammaInfoId",
                table: "GammaCalibrations",
                column: "GammaInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GammaInfos_MeasuringDeviceId",
                table: "GammaInfos",
                column: "MeasuringDeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringDevice_device_type_id",
                table: "MeasuringDevice",
                column: "device_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_PhoGammaInfos_MeasuringDeviceId",
                table: "PhoGammaInfos",
                column: "MeasuringDeviceId",
                unique: true);

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
                name: "IX_XRFInfos_MeasuringDeviceId",
                table: "XRFInfos",
                column: "MeasuringDeviceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GammaCalibrations");

            migrationBuilder.DropTable(
                name: "PhoGammaInfos");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "XRFInfos");

            migrationBuilder.DropTable(
                name: "GammaInfos");

            migrationBuilder.DropTable(
                name: "question_group");

            migrationBuilder.DropTable(
                name: "MeasuringDevice");

            migrationBuilder.DropTable(
                name: "DeviceType");
        }
    }
}
