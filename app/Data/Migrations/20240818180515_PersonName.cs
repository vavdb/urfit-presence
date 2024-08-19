using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace urfit_presence.Migrations
{
    /// <inheritdoc />
    public partial class PersonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "urfit",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurName",
                schema: "urfit",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurNamePrefix",
                schema: "urfit",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "urfit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurName",
                schema: "urfit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SurNamePrefix",
                schema: "urfit",
                table: "AspNetUsers");
        }
    }
}
