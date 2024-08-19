using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace urfit_presence.Migrations
{
    /// <inheritdoc />
    public partial class dayofweek_timeonly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "TimeSlots");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "TimeSlots",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DayOfWeek", "StartTime" },
                values: new object[] { 1, new TimeOnly(20, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DayOfWeek", "StartTime" },
                values: new object[] { 3, new TimeOnly(8, 45, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DayOfWeek", "StartTime" },
                values: new object[] { 3, new TimeOnly(20, 0, 0) });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DayOfWeek", "StartTime" },
                values: new object[] { 6, new TimeOnly(9, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "TimeSlots");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "TimeSlots",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Day", "StartTime" },
                values: new object[] { "Monday", "20:00" });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Day", "StartTime" },
                values: new object[] { "Wednesday", "08:45" });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Day", "StartTime" },
                values: new object[] { "Wednesday", "20:00" });

            migrationBuilder.UpdateData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Day", "StartTime" },
                values: new object[] { "Saturday", "20:00" });
        }
    }
}
