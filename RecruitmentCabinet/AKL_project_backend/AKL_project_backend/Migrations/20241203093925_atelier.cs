using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AKL_project_backend.Migrations
{
    /// <inheritdoc />
    public partial class atelier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deroulement_atelier",
                table: "Ateliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdReservateur",
                table: "Ateliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deroulement_atelier",
                table: "Ateliers");

            migrationBuilder.DropColumn(
                name: "IdReservateur",
                table: "Ateliers");
        }
    }
}
