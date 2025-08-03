using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class tow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authers_AutherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Books_BookId",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Users_UserId",
                table: "UserBook");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 10, 42, 870, DateTimeKind.Local).AddTicks(9702),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 10, 3, 59, 373, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 14, 10, 42, 870, DateTimeKind.Local).AddTicks(8343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 10, 3, 59, 373, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 10, 42, 870, DateTimeKind.Local).AddTicks(8002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 10, 3, 59, 373, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 10, 42, 869, DateTimeKind.Local).AddTicks(7273),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 10, 3, 59, 372, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authers_AutherId",
                table: "Books",
                column: "AutherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Books_BookId",
                table: "UserBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Users_UserId",
                table: "UserBook",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authers_AutherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Books_BookId",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Users_UserId",
                table: "UserBook");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 10, 3, 59, 373, DateTimeKind.Local).AddTicks(6886),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 10, 42, 870, DateTimeKind.Local).AddTicks(9702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 10, 3, 59, 373, DateTimeKind.Local).AddTicks(5555),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 14, 10, 42, 870, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 10, 3, 59, 373, DateTimeKind.Local).AddTicks(5208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 10, 42, 870, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 10, 3, 59, 372, DateTimeKind.Local).AddTicks(4310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 10, 42, 869, DateTimeKind.Local).AddTicks(7273));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authers_AutherId",
                table: "Books",
                column: "AutherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Books_BookId",
                table: "UserBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Users_UserId",
                table: "UserBook",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
