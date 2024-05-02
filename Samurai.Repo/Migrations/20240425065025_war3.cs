using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Samurai.Repo.Migrations
{
    /// <inheritdoc />
    public partial class war3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NinjaWar");

            migrationBuilder.DropTable(
                name: "VikingWar");

            migrationBuilder.AddColumn<int>(
                name: "NinjasId",
                table: "Wars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VikingsId",
                table: "Wars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Wars_NinjasId",
                table: "Wars",
                column: "NinjasId");

            migrationBuilder.CreateIndex(
                name: "IX_Wars_VikingsId",
                table: "Wars",
                column: "VikingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wars_Ninjas_NinjasId",
                table: "Wars",
                column: "NinjasId",
                principalTable: "Ninjas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wars_Vikings_VikingsId",
                table: "Wars",
                column: "VikingsId",
                principalTable: "Vikings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wars_Ninjas_NinjasId",
                table: "Wars");

            migrationBuilder.DropForeignKey(
                name: "FK_Wars_Vikings_VikingsId",
                table: "Wars");

            migrationBuilder.DropIndex(
                name: "IX_Wars_NinjasId",
                table: "Wars");

            migrationBuilder.DropIndex(
                name: "IX_Wars_VikingsId",
                table: "Wars");

            migrationBuilder.DropColumn(
                name: "NinjasId",
                table: "Wars");

            migrationBuilder.DropColumn(
                name: "VikingsId",
                table: "Wars");

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
    }
}
