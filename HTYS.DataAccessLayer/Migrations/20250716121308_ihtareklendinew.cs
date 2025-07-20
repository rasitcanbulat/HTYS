using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HTYS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ihtareklendinew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ihtarlar_Urunler_UrunId",
                table: "Ihtarlar");

            migrationBuilder.AddForeignKey(
                name: "FK_Ihtarlar_Urunler_UrunId",
                table: "Ihtarlar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ihtarlar_Urunler_UrunId",
                table: "Ihtarlar");

            migrationBuilder.AddForeignKey(
                name: "FK_Ihtarlar_Urunler_UrunId",
                table: "Ihtarlar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id");
        }
    }
}
