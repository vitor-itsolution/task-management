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
                    StartDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTask", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "TaskManagement",
                table: "PersonalTask",
                columns: new[] { "Id", "CreateDate", "Description", "EndDay", "StartDay", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("03a3156c-5f02-4426-b413-bb4dec67a72a"), new DateTime(2024, 5, 13, 23, 19, 57, 465, DateTimeKind.Local).AddTicks(60), "Api development", null, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Api development", null },
                    { new Guid("17855c71-f149-4012-be9b-600bcef38ce4"), new DateTime(2024, 5, 13, 23, 19, 57, 465, DateTimeKind.Local).AddTicks(50), "Final resource plan", null, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Final resource plan", null },
                    { new Guid("cf609937-ecd6-47a9-b1c3-4472d3fd9593"), new DateTime(2024, 5, 13, 23, 19, 57, 465, DateTimeKind.Local).AddTicks(10), "Set kick-off meeting", null, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Set kick-off meeting", null }
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
