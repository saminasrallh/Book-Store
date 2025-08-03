using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
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
                defaultValue: new DateTime(2025, 7, 31, 16, 49, 13, 424, DateTimeKind.Local).AddTicks(4919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 16, 49, 13, 424, DateTimeKind.Local).AddTicks(3704),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 16, 49, 13, 424, DateTimeKind.Local).AddTicks(3437),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 16, 49, 13, 423, DateTimeKind.Local).AddTicks(3927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 700, DateTimeKind.Local).AddTicks(3873));

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
                defaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(6649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 49, 13, 424, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 8, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(5248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 8, 31, 16, 49, 13, 424, DateTimeKind.Local).AddTicks(3704));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentalTime",
                table: "UserBook",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 701, DateTimeKind.Local).AddTicks(4889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 49, 13, 424, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 7, 31, 16, 42, 34, 700, DateTimeKind.Local).AddTicks(3873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 7, 31, 16, 49, 13, 423, DateTimeKind.Local).AddTicks(3927));

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
