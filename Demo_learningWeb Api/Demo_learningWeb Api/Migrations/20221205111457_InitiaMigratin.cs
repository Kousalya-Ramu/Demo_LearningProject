using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo_learningWeb_Api.Migrations
{
    public partial class InitiaMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    Populatation = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "walkDifficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_walkDifficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "walks",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: false),
                    WalkDifficultyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_walks", x => x.id);
                    table.ForeignKey(
                        name: "FK_walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_walks_walkDifficulties_WalkDifficultyId",
                        column: x => x.WalkDifficultyId,
                        principalTable: "walkDifficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_walks_RegionId",
                table: "walks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_walks_WalkDifficultyId",
                table: "walks",
                column: "WalkDifficultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "walks");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "walkDifficulties");
        }
    }
}
