using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacionamientoAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Placa);
                });

            migrationBuilder.CreateTable(
                name: "Estancias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estancias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estancias_Vehiculos_Placa",
                        column: x => x.Placa,
                        principalTable: "Vehiculos",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "Placa", "Tipo" },
                values: new object[,]
                {
                    { "ABC-12345", 0 },
                    { "DEF-23456", 1 },
                    { "GHI-34567", 2 },
                    { "JKL-45678", 1 },
                    { "MNO-56789", 2 }
                });

            migrationBuilder.InsertData(
                table: "Estancias",
                columns: new[] { "Id", "HoraEntrada", "HoraSalida", "Placa" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "ABC-12345" },
                    { 2, new DateTime(2023, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "DEF-23456" },
                    { 3, new DateTime(2023, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "GHI-34567" },
                    { 4, new DateTime(2023, 3, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "JKL-45678" },
                    { 5, new DateTime(2023, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), "MNO-56789" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estancias_Placa",
                table: "Estancias",
                column: "Placa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estancias");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
