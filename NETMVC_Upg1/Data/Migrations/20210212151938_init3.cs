using Microsoft.EntityFrameworkCore.Migrations;

namespace NETMVC_Upg1.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolClassViewModelId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolClassViewModelId",
                table: "AspNetUsers",
                column: "SchoolClassViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_SchoolClassViewModelId",
                table: "AspNetUsers",
                column: "SchoolClassViewModelId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_SchoolClassViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolClassViewModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SchoolClassViewModelId",
                table: "AspNetUsers");
        }
    }
}
