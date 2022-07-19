﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_app_server.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    TodoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TodoTitel = table.Column<string>(type: "TEXT", nullable: false),
                    TodoIsFinished = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.TodoID);
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "TodoID", "TodoIsFinished", "TodoTitel" },
                values: new object[] { 1, false, "Todo Item 1" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "TodoID", "TodoIsFinished", "TodoTitel" },
                values: new object[] { 2, false, "Todo Item 2" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "TodoID", "TodoIsFinished", "TodoTitel" },
                values: new object[] { 3, false, "Todo Item 3" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "TodoID", "TodoIsFinished", "TodoTitel" },
                values: new object[] { 4, false, "Todo Item 4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "TodoID", "TodoIsFinished", "TodoTitel" },
                values: new object[] { 5, false, "Todo Item 5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
