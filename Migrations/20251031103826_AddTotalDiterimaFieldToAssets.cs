using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBN_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalDiterimaFieldToAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Buyers_BuyerId_Buyer",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_SBNs_SbnId_Sbn",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_BuyerId_Buyer",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_SbnId_Sbn",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "BuyerId_Buyer",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "SbnId_Sbn",
                table: "Assets");

            migrationBuilder.AddColumn<double>(
                name: "Total_Diterima",
                table: "Assets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Id_Buyer",
                table: "Assets",
                column: "Id_Buyer");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Id_Sbn",
                table: "Assets",
                column: "Id_Sbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Buyers_Id_Buyer",
                table: "Assets",
                column: "Id_Buyer",
                principalTable: "Buyers",
                principalColumn: "Id_Buyer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_SBNs_Id_Sbn",
                table: "Assets",
                column: "Id_Sbn",
                principalTable: "SBNs",
                principalColumn: "Id_Sbn",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Buyers_Id_Buyer",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_SBNs_Id_Sbn",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Id_Buyer",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Id_Sbn",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Total_Diterima",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "BuyerId_Buyer",
                table: "Assets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SbnId_Sbn",
                table: "Assets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_BuyerId_Buyer",
                table: "Assets",
                column: "BuyerId_Buyer");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SbnId_Sbn",
                table: "Assets",
                column: "SbnId_Sbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Buyers_BuyerId_Buyer",
                table: "Assets",
                column: "BuyerId_Buyer",
                principalTable: "Buyers",
                principalColumn: "Id_Buyer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_SBNs_SbnId_Sbn",
                table: "Assets",
                column: "SbnId_Sbn",
                principalTable: "SBNs",
                principalColumn: "Id_Sbn",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
