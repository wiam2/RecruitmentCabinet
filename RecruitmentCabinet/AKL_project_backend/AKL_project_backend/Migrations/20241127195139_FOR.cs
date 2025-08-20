using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AKL_project_backend.Migrations
{
    /// <inheritdoc />
    public partial class FOR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "Formations");

            migrationBuilder.RenameColumn(
                name: "Ville",
                table: "Formations",
                newName: "Specialite");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Formations",
                newName: "Diplome");

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Formations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Formations");

            migrationBuilder.RenameColumn(
                name: "Specialite",
                table: "Formations",
                newName: "Ville");

            migrationBuilder.RenameColumn(
                name: "Diplome",
                table: "Formations",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebut",
                table: "Formations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFin",
                table: "Formations",
                type: "datetime2",
                nullable: true);
        }
    }
}
