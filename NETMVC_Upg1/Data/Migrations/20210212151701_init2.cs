using Microsoft.EntityFrameworkCore.Migrations;

namespace NETMVC_Upg1.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UsersId",
                table: "Classes",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_UsersId",
                table: "Classes",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_UsersId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_UsersId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Classes");
        }
    }
}
