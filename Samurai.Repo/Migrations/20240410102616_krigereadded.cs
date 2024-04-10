using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samurai.Repo.Migrations
{
    /// <inheritdoc />
    public partial class krigereadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kriger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kriger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KrigerSamurais",
                columns: table => new
                {
                    KrigereId = table.Column<int>(type: "int", nullable: false),
                    SamuraisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrigerSamurais", x => new { x.KrigereId, x.SamuraisId });
                    table.ForeignKey(
                        name: "FK_KrigerSamurais_Kriger_KrigereId",
                        column: x => x.KrigereId,
                        principalTable: "Kriger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KrigerSamurais_Samurais_SamuraisId",
                        column: x => x.SamuraisId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KrigerSamurais_SamuraisId",
                table: "KrigerSamurais",
                column: "SamuraisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KrigerSamurais");

            migrationBuilder.DropTable(
                name: "Kriger");
        }
    }
}
