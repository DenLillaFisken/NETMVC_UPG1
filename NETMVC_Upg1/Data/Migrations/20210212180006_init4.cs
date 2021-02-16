using Microsoft.EntityFrameworkCore.Migrations;

namespace NETMVC_Upg1.Data.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_UsersId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Classes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_UsersId",
                table: "Classes",
                newName: "IX_Classes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_UserId",
                table: "Classes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_UserId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Classes",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_UserId",
                table: "Classes",
                newName: "IX_Classes_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_UsersId",
                table: "Classes",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
