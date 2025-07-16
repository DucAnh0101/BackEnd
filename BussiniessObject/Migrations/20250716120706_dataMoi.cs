using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusiniessObject.Migrations
{
    /// <inheritdoc />
    public partial class dataMoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GammaDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GammaDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoGammaDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    K = table.Column<double>(type: "float", nullable: true),
                    U = table.Column<double>(type: "float", nullable: true),
                    Th = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoGammaDevices", x => x.Id);
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
                name: "XrfDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XrfDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GammaCalibrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeValue = table.Column<double>(type: "float", nullable: false),
                    Coefficient = table.Column<double>(type: "float", nullable: false),
                    GammaDeviceId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GammaCalibrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GammaCalibrations_GammaDevices_GammaDeviceId",
                        column: x => x.GammaDeviceId,
                        principalTable: "GammaDevices",
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

            migrationBuilder.InsertData(
                table: "GammaDevices",
                columns: new[] { "Id", "SerialNumber", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "GAM-001", "Active", 0 },
                    { 2, "GAM-002", "Active", 0 }
                });

            migrationBuilder.InsertData(
                table: "PhoGammaDevices",
                columns: new[] { "Id", "K", "SerialNumber", "Status", "Th", "Type", "U" },
                values: new object[,]
                {
                    { 1, 10.5, "PHO-001", "Active", 14.199999999999999, 1, 12.300000000000001 },
                    { 2, 11.5, "PHO-002", "Active", 15.199999999999999, 1, 13.300000000000001 }
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
                table: "XrfDevices",
                columns: new[] { "Id", "Note", "SerialNumber", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "Initial XRF device", "XRF-001", "Active", 2 },
                    { 2, "Backup device", "XRF-002", "Active", 2 }
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
                table: "GammaCalibrations",
                columns: new[] { "Id", "Coefficient", "GammaDeviceId", "RangeValue", "Status" },
                values: new object[,]
                {
                    { 1, 1.5, 1, 0.10000000000000001, "Active" },
                    { 2, 2.5, 1, 0.20000000000000001, "Active" },
                    { 3, 3.5, 2, 0.29999999999999999, "Active" }
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

            migrationBuilder.CreateIndex(
                name: "IX_GammaCalibrations_GammaDeviceId",
                table: "GammaCalibrations",
                column: "GammaDeviceId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GammaCalibrations");

            migrationBuilder.DropTable(
                name: "PhoGammaDevices");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "XrfDevices");

            migrationBuilder.DropTable(
                name: "GammaDevices");

            migrationBuilder.DropTable(
                name: "question_group");
        }
    }
}
