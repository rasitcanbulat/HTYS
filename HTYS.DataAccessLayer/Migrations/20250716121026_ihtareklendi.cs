using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HTYS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ihtareklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ihtarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    NoterAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    YevmiyeNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IhtarTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IhtarnameSuresi = table.Column<int>(type: "int", nullable: false),
                    TebligTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IhtarTebligGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KatTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IhtarnameNakitTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IhtarnameGayriNakitTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IhtarNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ihtarlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ihtarlar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ihtarlar_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ihtarlar_MusteriId",
                table: "Ihtarlar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Ihtarlar_UrunId",
                table: "Ihtarlar",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ihtarlar");
        }
    }
}
