using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HTYS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class icraeklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcraTakipleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    AvukatId = table.Column<int>(type: "int", nullable: false),
                    TakipTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TakipTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IhtarId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    IcraMudurugu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IcraDosyaNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    MahiyetKodu = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcraTakipleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IcraTakipleri_Avukatlar_AvukatId",
                        column: x => x.AvukatId,
                        principalTable: "Avukatlar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IcraTakipleri_Ihtarlar_IhtarId",
                        column: x => x.IhtarId,
                        principalTable: "Ihtarlar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IcraTakipleri_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IcraTakipleri_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IcraTakipleri_AvukatId",
                table: "IcraTakipleri",
                column: "AvukatId");

            migrationBuilder.CreateIndex(
                name: "IX_IcraTakipleri_IhtarId",
                table: "IcraTakipleri",
                column: "IhtarId");

            migrationBuilder.CreateIndex(
                name: "IX_IcraTakipleri_MusteriId",
                table: "IcraTakipleri",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_IcraTakipleri_UrunId",
                table: "IcraTakipleri",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcraTakipleri");
        }
    }
}
