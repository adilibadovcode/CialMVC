using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CialMVC.Migrations
{
    public partial class CategoryTablesCreated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experts_Categories_CategoryId",
                table: "Experts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Experts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Experts_Categories_CategoryId",
                table: "Experts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experts_Categories_CategoryId",
                table: "Experts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Experts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Experts_Categories_CategoryId",
                table: "Experts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
