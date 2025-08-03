using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class threp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(4432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 25, 15, 47, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(3039),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 14, 25, 15, 47, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(2689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 25, 15, 47, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 196, DateTimeKind.Local).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 25, 15, 46, DateTimeKind.Local).AddTicks(1138));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 25, 15, 47, DateTimeKind.Local).AddTicks(3649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 14, 25, 15, 47, DateTimeKind.Local).AddTicks(2277),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 25, 15, 47, DateTimeKind.Local).AddTicks(1973),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 197, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 25, 15, 46, DateTimeKind.Local).AddTicks(1138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 27, 56, 196, DateTimeKind.Local).AddTicks(1996));
        }
    }
}
