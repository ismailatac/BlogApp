using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notification_writer_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Notifications",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_WriterId",
                table: "Notifications",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Writers_WriterId",
                table: "Notifications",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Writers_WriterId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_WriterId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Notifications");
        }
    }
}
