using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class newWeather_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityWeather");

            migrationBuilder.DropTable(
                name: "MainWeather");

            migrationBuilder.DropTable(
                name: "Wind");

            migrationBuilder.CreateTable(
                name: "NewCityWeather",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temp = table.Column<float>(type: "real", nullable: false),
                    speed = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCityWeather", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewCityWeather");

            migrationBuilder.CreateTable(
                name: "MainWeather",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feels_like = table.Column<float>(type: "real", nullable: false),
                    humidity = table.Column<int>(type: "int", nullable: false),
                    pressure = table.Column<int>(type: "int", nullable: false),
                    temp = table.Column<float>(type: "real", nullable: false),
                    temp_max = table.Column<float>(type: "real", nullable: false),
                    temp_min = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainWeather", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deg = table.Column<float>(type: "real", nullable: false),
                    speed = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CityWeather",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityWeather", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CityWeather_MainWeather_MainID",
                        column: x => x.MainID,
                        principalTable: "MainWeather",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CityWeather_Wind_WindID",
                        column: x => x.WindID,
                        principalTable: "Wind",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityWeather_MainID",
                table: "CityWeather",
                column: "MainID");

            migrationBuilder.CreateIndex(
                name: "IX_CityWeather_WindID",
                table: "CityWeather",
                column: "WindID");
        }
    }
}
