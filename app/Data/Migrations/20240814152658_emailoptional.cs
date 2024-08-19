using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace urfit_presence.Migrations
{
    /// <inheritdoc />
    public partial class emailoptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "urfit");

            migrationBuilder.RenameTable(
                name: "TimeSlots",
                newName: "TimeSlots",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "Presences",
                newName: "Presences",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "People",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "urfit");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "urfit");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "urfit",
                table: "People",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                schema: "urfit",
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Leydi van den Braken Breuls");

            migrationBuilder.UpdateData(
                schema: "urfit",
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Vincent van den Braken Breuls");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TimeSlots",
                schema: "urfit",
                newName: "TimeSlots");

            migrationBuilder.RenameTable(
                name: "Presences",
                schema: "urfit",
                newName: "Presences");

            migrationBuilder.RenameTable(
                name: "People",
                schema: "urfit",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "urfit",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "urfit",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "urfit",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "urfit",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "urfit",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "urfit",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "urfit",
                newName: "AspNetRoleClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Leydi");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Vincent van den Braken");
        }
    }
}
