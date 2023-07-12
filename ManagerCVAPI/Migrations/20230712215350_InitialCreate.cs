using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManagerCVAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sedi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Città = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecapitoTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedi", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sedi",
                columns: new[] { "Id", "Cap", "Città", "Email", "Indirizzo", "Provincia", "RecapitoTel" },
                values: new object[,]
                {
                    { 1, "80143", "Napoli", "info.napoli@bcsoft.net", "Via Taddeo da Sessa - Centro direzionale isola F10", "Napoli", "0815536002" },
                    { 2, "00144", "Roma", "info.roma@bcsoft.net", "Viale della Tecnica, 245", "Roma", "068080237" },
                    { 3, "50123", "Firenze", "info.firenze@bcsoft.net", "Via Borgo Ognissanti 54", "Firenze", "0559861922" },
                    { 4, "40121", "Bologna", "info.bologna@bcsoft.net", "Via Majani 2", "Bologna", "0519921991" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sedi");
        }
    }
}
