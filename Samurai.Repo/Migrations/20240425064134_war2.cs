using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samurai.Repo.Migrations
{
    /// <inheritdoc />
    public partial class war2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weapon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vikings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mead = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vikings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NinjaWar",
                columns: table => new
                {
                    NinjasId = table.Column<int>(type: "int", nullable: false),
                    WarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinjaWar", x => new { x.NinjasId, x.WarsId });
                    table.ForeignKey(
                        name: "FK_NinjaWar_Ninjas_NinjasId",
                        column: x => x.NinjasId,
                        principalTable: "Ninjas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NinjaWar_Wars_WarsId",
                        column: x => x.WarsId,
                        principalTable: "Wars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VikingWar",
                columns: table => new
                {
                    VikingsId = table.Column<int>(type: "int", nullable: false),
                    WarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VikingWar", x => new { x.VikingsId, x.WarsId });
                    table.ForeignKey(
                        name: "FK_VikingWar_Vikings_VikingsId",
                        column: x => x.VikingsId,
                        principalTable: "Vikings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VikingWar_Wars_WarsId",
                        column: x => x.WarsId,
                        principalTable: "Wars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NinjaWar_WarsId",
                table: "NinjaWar",
                column: "WarsId");

            migrationBuilder.CreateIndex(
                name: "IX_VikingWar_WarsId",
                table: "VikingWar",
                column: "WarsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NinjaWar");

            migrationBuilder.DropTable(
                name: "VikingWar");

            migrationBuilder.DropTable(
                name: "Ninjas");

            migrationBuilder.DropTable(
                name: "Vikings");

            migrationBuilder.DropTable(
                name: "Wars");
        }
    }
}
