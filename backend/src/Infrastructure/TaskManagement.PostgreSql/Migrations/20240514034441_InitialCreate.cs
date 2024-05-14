using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TaskManagement");

            migrationBuilder.CreateTable(
                name: "PersonalTask",
                schema: "TaskManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDay = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDay = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTask", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "TaskManagement",
                table: "PersonalTask",
                columns: new[] { "Id", "CreateDate", "Description", "EndDay", "StartDay", "State", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("70bbcb75-affb-4c85-999a-77aea00ed55a"), new DateTime(2024, 5, 14, 0, 44, 41, 618, DateTimeKind.Local).AddTicks(2780), "Api development", null, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Api development", null },
                    { new Guid("a9aa4c4f-3077-4276-867c-59fba7959d19"), new DateTime(2024, 5, 14, 0, 44, 41, 618, DateTimeKind.Local).AddTicks(2750), "Set kick-off meeting", null, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Set kick-off meeting", null },
                    { new Guid("ac2be6ff-0c80-4d51-8624-f9c97a0abb4b"), new DateTime(2024, 5, 14, 0, 44, 41, 618, DateTimeKind.Local).AddTicks(2780), "Final resource plan", null, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Final resource plan", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalTask",
                schema: "TaskManagement");
        }
    }
}
