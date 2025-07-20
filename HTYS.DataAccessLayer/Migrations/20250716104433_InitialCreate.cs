using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HTYS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avukatlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCKN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    VergiDairesi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaksNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvukatTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HalkbankVadesizIBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigerBankaIBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TamAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HesapAktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avukatlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciTipi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TCKN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DogumYeri = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedeniDurum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BabaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasaportNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    NufusaKayitliIl = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CiltNo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AileSiraNo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    KutukSiraNo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AdresDetay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiDairesi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VergiNo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    HayattaMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilceler_Iller_IlId",
                        column: x => x.IlId,
                        principalTable: "Iller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    AvukatId = table.Column<int>(type: "int", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    KrediBirimKodu = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TakipMiktari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DovizTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AylikFaizOrani = table.Column<double>(type: "float", nullable: false),
                    TakipTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MasrafBakiyesi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaizBakiyesi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urunler_Avukatlar_AvukatId",
                        column: x => x.AvukatId,
                        principalTable: "Avukatlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Urunler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semtler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semtler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semtler_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilceler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_IlId",
                table: "Ilceler",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Semtler_IlceId",
                table: "Semtler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_AvukatId",
                table: "Urunler",
                column: "AvukatId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_MusteriId",
                table: "Urunler",
                column: "MusteriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginAccounts");

            migrationBuilder.DropTable(
                name: "Semtler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "Avukatlar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Iller");
        }
    }
}
