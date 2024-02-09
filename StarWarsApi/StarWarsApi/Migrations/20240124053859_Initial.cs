using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWarsApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cost_in_credits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    length = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    max_atmosphering_speed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passengers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cargo_capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consumables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hyperdrive_rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MGLT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    starship_class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pilots = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    films = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    edited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Starships");
        }
    }
}
