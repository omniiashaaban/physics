using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Physics.DAL.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Devices_DeviceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeviceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeviceId",
                table: "Users",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Devices_DeviceId",
                table: "Users",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
