using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace urfit_presence.Migrations
{
    /// <inheritdoc />
    public partial class addInformerRelationid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InformationRelationId",
                schema: "urfit",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InformationRelationId",
                schema: "urfit",
                table: "AspNetUsers");
        }
    }
}
