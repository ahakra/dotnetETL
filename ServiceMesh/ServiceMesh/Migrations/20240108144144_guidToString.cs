using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceMesh.Migrations
{
    /// <inheritdoc />
    public partial class guidToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAdapters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtocolUsed = table.Column<int>(type: "int", nullable: false),
                    ProtocolDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceInfoEntityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAdapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAdapters_ServiceInfos_ServiceInfoEntityId",
                        column: x => x.ServiceInfoEntityId,
                        principalTable: "ServiceInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServiceInfos",
                columns: new[] { "Id", "ServiceType", "Timestamp" },
                values: new object[,]
                {
                    { "80abbca8-664d-4b20-b5de-024705497d4a", "LoggerService", new DateTime(2024, 1, 8, 16, 41, 43, 984, DateTimeKind.Local).AddTicks(4348) },
                    { "80abbca8-664d-4b20-b5de-024705497d5b", "AuthenticationService", new DateTime(2024, 1, 8, 16, 41, 43, 984, DateTimeKind.Local).AddTicks(4412) }
                });

            migrationBuilder.InsertData(
                table: "ServiceAdapters",
                columns: new[] { "Id", "Address", "ProtocolDescription", "ProtocolUsed", "ServiceInfoEntityId" },
                values: new object[,]
                {
                    { "90abbca8-664d-4b20-b5de-024705497d4a", "127.0.0.1", "/api", 1, "80abbca8-664d-4b20-b5de-024705497d4a" },
                    { "91abbca8-664d-4b20-b5de-024705497d4a", "localhost:50051", "com.example.Greeter/SayHello", 3, "80abbca8-664d-4b20-b5de-024705497d4a" },
                    { "92abbca8-664d-4b20-b5de-024705497d4a", "127.0.0.2", "/api", 3, "80abbca8-664d-4b20-b5de-024705497d5b" },
                    { "93abbca8-664d-4b20-b5de-024705497d4a", "localhost:50053", "com.example.Greeter/SayHello", 2, "80abbca8-664d-4b20-b5de-024705497d5b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAdapters_ServiceInfoEntityId",
                table: "ServiceAdapters",
                column: "ServiceInfoEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceAdapters");

            migrationBuilder.DropTable(
                name: "ServiceInfos");
        }
    }
}
