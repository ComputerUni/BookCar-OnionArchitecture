using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_remove_cardescriptionid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarDescriptionId",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarDescriptionId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
