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
                name: "ethnos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    men_quantity = table.Column<int>(type: "integer", nullable: false),
                    women_quantity = table.Column<int>(type: "integer", nullable: false),
                    demography_data_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ethnos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_region", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "demography_data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    region_id = table.Column<Guid>(type: "uuid", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demography_data", x => x.id);
                    table.ForeignKey(
                        name: "FK_demography_data_region_region_id",
                        column: x => x.region_id,
                        principalTable: "region",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "age",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    men_quantity = table.Column<int>(type: "integer", nullable: false),
                    women_quantity = table.Column<int>(type: "integer", nullable: false),
                    age_value = table.Column<int>(type: "integer", nullable: false),
                    demography_data_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_age", x => x.id);
                    table.ForeignKey(
                        name: "FK_age_demography_data_demography_data_id",
                        column: x => x.demography_data_id,
                        principalTable: "demography_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemographyDataEthnos",
                columns: table => new
                {
                    DemographyDatumId = table.Column<Guid>(type: "uuid", nullable: false),
                    EthnicGroupsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemographyDataEthnos", x => new { x.DemographyDatumId, x.EthnicGroupsId });
                    table.ForeignKey(
                        name: "FK_DemographyDataEthnos_demography_data_DemographyDatumId",
                        column: x => x.DemographyDatumId,
                        principalTable: "demography_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemographyDataEthnos_ethnos_EthnicGroupsId",
                        column: x => x.EthnicGroupsId,
                        principalTable: "ethnos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "density",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_size = table.Column<double>(type: "double precision", nullable: false),
                    population_size = table.Column<int>(type: "integer", nullable: false),
                    population_density = table.Column<double>(type: "double precision", nullable: false),
                    demography_data_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_density", x => x.id);
                    table.ForeignKey(
                        name: "FK_density_demography_data_demography_data_id",
                        column: x => x.demography_data_id,
                        principalTable: "demography_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "migration",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    migrants_count = table.Column<int>(type: "integer", nullable: false),
                    emigrants_count = table.Column<int>(type: "integer", nullable: false),
                    migration_ratio = table.Column<int>(type: "integer", nullable: false),
                    demography_data_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_migration", x => x.id);
                    table.ForeignKey(
                        name: "FK_migration_demography_data_demography_data_id",
                        column: x => x.demography_data_id,
                        principalTable: "demography_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natural_growth",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bith_rate = table.Column<int>(type: "integer", nullable: false),
                    mortality_rate = table.Column<int>(type: "integer", nullable: false),
                    demography_data_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_natural_growth", x => x.id);
                    table.ForeignKey(
                        name: "FK_natural_growth_demography_data_demography_data_id",
                        column: x => x.demography_data_id,
                        principalTable: "demography_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_age_demography_data_id",
                table: "age",
                column: "demography_data_id");

            migrationBuilder.CreateIndex(
                name: "IX_demography_data_region_id",
                table: "demography_data",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_DemographyDataEthnos_EthnicGroupsId",
                table: "DemographyDataEthnos",
                column: "EthnicGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_density_demography_data_id",
                table: "density",
                column: "demography_data_id");

            migrationBuilder.CreateIndex(
                name: "IX_migration_demography_data_id",
                table: "migration",
                column: "demography_data_id");

            migrationBuilder.CreateIndex(
                name: "IX_natural_growth_demography_data_id",
                table: "natural_growth",
                column: "demography_data_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "age");

            migrationBuilder.DropTable(
                name: "DemographyDataEthnos");

            migrationBuilder.DropTable(
                name: "density");

            migrationBuilder.DropTable(
                name: "migration");

            migrationBuilder.DropTable(
                name: "natural_growth");

            migrationBuilder.DropTable(
                name: "ethnos");

            migrationBuilder.DropTable(
                name: "demography_data");

            migrationBuilder.DropTable(
                name: "region");
        }
    }
}
