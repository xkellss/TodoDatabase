using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedDateCompletedDateandIsCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "TodoTasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TodoTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TodoTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TodoTasks");
        }
    }
}
