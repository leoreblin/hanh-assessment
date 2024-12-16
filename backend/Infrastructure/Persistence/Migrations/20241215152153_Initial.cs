using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Attributes_BreedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Attributes_BreedDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LifeRangeMax = table.Column<int>(type: "int", nullable: false),
                    LifeRangeMin = table.Column<int>(type: "int", nullable: false),
                    MaleWeightRangeMax = table.Column<int>(type: "int", nullable: false),
                    MaleWeightRangeMin = table.Column<int>(type: "int", nullable: false),
                    FemaleWeightRangeMax = table.Column<int>(type: "int", nullable: false),
                    FemaleWeightRangeMin = table.Column<int>(type: "int", nullable: false),
                    Attributes_Hypoallergenic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breeds");
        }
    }
}
