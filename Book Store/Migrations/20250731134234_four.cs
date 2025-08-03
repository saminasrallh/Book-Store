using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(6649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(5248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(4889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 700, DateTimeKind.Local).AddTicks(3873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 196, DateTimeKind.Local).AddTicks(1996));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(4432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(3039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(2689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 196, DateTimeKind.Local).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 700, DateTimeKind.Local).AddTicks(3873));
        }
    }
}
