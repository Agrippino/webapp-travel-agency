using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class MappaturaModelViaggio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viaggi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImmagineViaggio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitoloViaggio = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DescrizioneViaggio = table.Column<string>(type: "Text", maxLength: 1000, nullable: false),
                    DurataViaggio = table.Column<int>(type: "int", nullable: false),
                    DestinazioniViaggio = table.Column<int>(type: "int", nullable: false),
                    CostoViaggio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaggi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viaggi");
        }
    }
}
