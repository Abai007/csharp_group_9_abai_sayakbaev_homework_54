using Microsoft.EntityFrameworkCore.Migrations;

namespace homework_54.Migrations
{
    public partial class ChangeSave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Brends_BrendId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "BrendId",
                table: "Reviews",
                newName: "PhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BrendId",
                table: "Reviews",
                newName: "IX_Reviews_PhoneId");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_PhoneId",
                table: "Reviews",
                column: "PhoneId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_PhoneId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "PhoneId",
                table: "Reviews",
                newName: "BrendId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PhoneId",
                table: "Reviews",
                newName: "IX_Reviews_BrendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Brends_BrendId",
                table: "Reviews",
                column: "BrendId",
                principalTable: "Brends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
