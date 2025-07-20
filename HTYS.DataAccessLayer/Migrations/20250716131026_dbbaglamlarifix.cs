using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HTYS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class dbbaglamlarifix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcraTakipleri_Ihtarlar_IhtarId",
                table: "IcraTakipleri");

            migrationBuilder.AddForeignKey(
                name: "FK_IcraTakipleri_Ihtarlar_IhtarId",
                table: "IcraTakipleri",
                column: "IhtarId",
                principalTable: "Ihtarlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcraTakipleri_Ihtarlar_IhtarId",
                table: "IcraTakipleri");

            migrationBuilder.AddForeignKey(
                name: "FK_IcraTakipleri_Ihtarlar_IhtarId",
                table: "IcraTakipleri",
                column: "IhtarId",
                principalTable: "Ihtarlar",
                principalColumn: "Id");
        }
    }
}
