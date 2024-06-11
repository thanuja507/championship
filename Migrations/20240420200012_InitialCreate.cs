using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1Championship.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TeamPrincipal = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Chassis = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Drivers = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
