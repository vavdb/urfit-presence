using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace urfit_presence.Migrations
{
    /// <inheritdoc />
    public partial class users_instead_of_people : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presences_People_PersonId",
                schema: "urfit",
                table: "Presences");

            migrationBuilder.DropTable(
                name: "People",
                schema: "urfit");

            migrationBuilder.DropIndex(
                name: "IX_Presences_PersonId",
                schema: "urfit",
                table: "Presences");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "urfit",
                table: "Presences");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "urfit",
                table: "Presences",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Presences_ApplicationUserId",
                schema: "urfit",
                table: "Presences",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presences_AspNetUsers_ApplicationUserId",
                schema: "urfit",
                table: "Presences",
                column: "ApplicationUserId",
                principalSchema: "urfit",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presences_AspNetUsers_ApplicationUserId",
                schema: "urfit",
                table: "Presences");

            migrationBuilder.DropIndex(
                name: "IX_Presences_ApplicationUserId",
                schema: "urfit",
                table: "Presences");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "urfit",
                table: "Presences");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                schema: "urfit",
                table: "Presences",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "People",
                schema: "urfit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "urfit",
                table: "People",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "leydi@urfit.nu", "Leydi van den Braken Breuls" },
                    { 2, "vincent@vandenbraken.com", "Vincent van den Braken Breuls" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presences_PersonId",
                schema: "urfit",
                table: "Presences",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presences_People_PersonId",
                schema: "urfit",
                table: "Presences",
                column: "PersonId",
                principalSchema: "urfit",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
