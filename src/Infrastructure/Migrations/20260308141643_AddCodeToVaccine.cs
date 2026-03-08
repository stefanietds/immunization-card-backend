using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace immunization_card_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCodeToVaccine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Vaccines",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Vaccines");
        }
    }
}
