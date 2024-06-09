using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace İleri_Veri_tabani.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerAge = table.Column<int>(type: "int", nullable: false),
                    PlayerPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerSquad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerMinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    PlayerTouches = table.Column<float>(type: "real", nullable: false),
                    PlayerTackles = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
