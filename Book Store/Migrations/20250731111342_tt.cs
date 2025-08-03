using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
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
                defaultValue: new DateTime(2025, 7, 31, 14, 13, 42, 33, DateTimeKind.Local).AddTicks(8885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 12, 39, 499, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 14, 13, 42, 33, DateTimeKind.Local).AddTicks(7313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 14, 12, 39, 499, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 13, 42, 33, DateTimeKind.Local).AddTicks(6926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 12, 39, 499, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 13, 42, 32, DateTimeKind.Local).AddTicks(4022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 12, 39, 498, DateTimeKind.Local).AddTicks(6947));

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
                defaultValue: new DateTime(2025, 7, 31, 14, 12, 39, 499, DateTimeKind.Local).AddTicks(7867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 13, 42, 33, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 14, 12, 39, 499, DateTimeKind.Local).AddTicks(6678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 14, 13, 42, 33, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 12, 39, 499, DateTimeKind.Local).AddTicks(6414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 13, 42, 33, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 14, 12, 39, 498, DateTimeKind.Local).AddTicks(6947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 14, 13, 42, 32, DateTimeKind.Local).AddTicks(4022));

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
    }
}
