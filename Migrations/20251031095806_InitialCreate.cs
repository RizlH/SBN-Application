using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SBN_Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id_Buyer = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama_Buyer = table.Column<string>(type: "text", nullable: false),
                    No_Telp = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    No_Rek = table.Column<string>(type: "text", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id_Buyer);
                });

            migrationBuilder.CreateTable(
                name: "SBNs",
                columns: table => new
                {
                    Id_Sbn = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama_Sbn = table.Column<string>(type: "text", nullable: false),
                    Kode_Sbn = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Tipe_Investor = table.Column<string>(type: "text", nullable: false),
                    Min_Beli = table.Column<int>(type: "integer", nullable: false),
                    Fixed_Rate = table.Column<double>(type: "double precision", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBNs", x => x.Id_Sbn);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id_Asset = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Buyer = table.Column<int>(type: "integer", nullable: false),
                    Id_Sbn = table.Column<int>(type: "integer", nullable: false),
                    Modal = table.Column<int>(type: "integer", nullable: false),
                    Tenor = table.Column<int>(type: "integer", nullable: false),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BuyerId_Buyer = table.Column<int>(type: "integer", nullable: false),
                    SbnId_Sbn = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id_Asset);
                    table.ForeignKey(
                        name: "FK_Assets_Buyers_BuyerId_Buyer",
                        column: x => x.BuyerId_Buyer,
                        principalTable: "Buyers",
                        principalColumn: "Id_Buyer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_SBNs_SbnId_Sbn",
                        column: x => x.SbnId_Sbn,
                        principalTable: "SBNs",
                        principalColumn: "Id_Sbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_BuyerId_Buyer",
                table: "Assets",
                column: "BuyerId_Buyer");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SbnId_Sbn",
                table: "Assets",
                column: "SbnId_Sbn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "SBNs");
        }
    }
}
