using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace il_mio_fotoalbum.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Foto",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Foto",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foto_UserId1",
                table: "Foto",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_AspNetUsers_UserId1",
                table: "Foto",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_AspNetUsers_UserId1",
                table: "Foto");

            migrationBuilder.DropIndex(
                name: "IX_Foto_UserId1",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Foto");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Foto");
        }
    }
}
