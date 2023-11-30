using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "demography_data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demography_data", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "age",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    men_quantity = table.Column<int>(type: "integer", nullable: false),
                    women_quantity = table.Column<int>(type: "integer", nullable: false),
                    age_value = table.Column<int>(type: "integer", nullable: false),
                    DemographyDataId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_age", x => x.id);
                    table.ForeignKey(
                        name: "FK_age_demography_data_DemographyDataId",
                        column: x => x.DemographyDataId,
                        principalTable: "demography_data",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "density",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_size = table.Column<double>(type: "double precision", nullable: false),
                    population_size = table.Column<int>(type: "integer", nullable: false),
                    population_density = table.Column<double>(type: "double precision", nullable: false),
                    DemographyDataId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_density", x => x.id);
                    table.ForeignKey(
                        name: "FK_density_demography_data_DemographyDataId",
                        column: x => x.DemographyDataId,
                        principalTable: "demography_data",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ethnos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    men_quantity = table.Column<int>(type: "integer", nullable: false),
                    women_quantity = table.Column<int>(type: "integer", nullable: false),
                    DemographyDataId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ethnos", x => x.id);
                    table.ForeignKey(
                        name: "FK_ethnos_demography_data_DemographyDataId",
                        column: x => x.DemographyDataId,
                        principalTable: "demography_data",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "natural_growth",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bith_rate = table.Column<int>(type: "integer", nullable: false),
                    mortality_rate = table.Column<int>(type: "integer", nullable: false),
                    DemographyDataId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_natural_growth", x => x.id);
                    table.ForeignKey(
                        name: "FK_natural_growth_demography_data_DemographyDataId",
                        column: x => x.DemographyDataId,
                        principalTable: "demography_data",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    DemographyDataId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.id);
                    table.ForeignKey(
                        name: "FK_region_demography_data_DemographyDataId",
                        column: x => x.DemographyDataId,
                        principalTable: "demography_data",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_age_DemographyDataId",
                table: "age",
                column: "DemographyDataId");

            migrationBuilder.CreateIndex(
                name: "IX_density_DemographyDataId",
                table: "density",
                column: "DemographyDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ethnos_DemographyDataId",
                table: "ethnos",
                column: "DemographyDataId");

            migrationBuilder.CreateIndex(
                name: "IX_natural_growth_DemographyDataId",
                table: "natural_growth",
                column: "DemographyDataId");

            migrationBuilder.CreateIndex(
                name: "IX_region_DemographyDataId",
                table: "region",
                column: "DemographyDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "age");

            migrationBuilder.DropTable(
                name: "density");

            migrationBuilder.DropTable(
                name: "ethnos");

            migrationBuilder.DropTable(
                name: "natural_growth");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "demography_data");
        }
    }
}
