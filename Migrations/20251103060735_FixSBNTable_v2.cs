using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBN_Application.Migrations
{
    /// <inheritdoc />
    public partial class FixSBNTable_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_SBNs_Id_Sbn",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBNs",
                table: "SBNs");

            migrationBuilder.RenameTable(
                name: "SBNs",
                newName: "SBN");

            migrationBuilder.AlterColumn<string>(
                name: "Tipe_Investor",
                table: "SBN",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nama_Sbn",
                table: "SBN",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Kode_Sbn",
                table: "SBN",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Deskripsi",
                table: "SBN",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "SBN",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBN",
                table: "SBN",
                column: "Id_Sbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_SBN_Id_Sbn",
                table: "Assets",
                column: "Id_Sbn",
                principalTable: "SBN",
                principalColumn: "Id_Sbn",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_SBN_Id_Sbn",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SBN",
                table: "SBN");

            migrationBuilder.RenameTable(
                name: "SBN",
                newName: "SBNs");

            migrationBuilder.AlterColumn<string>(
                name: "Tipe_Investor",
                table: "SBNs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nama_Sbn",
                table: "SBNs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Kode_Sbn",
                table: "SBNs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Deskripsi",
                table: "SBNs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "SBNs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SBNs",
                table: "SBNs",
                column: "Id_Sbn");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_SBNs_Id_Sbn",
                table: "Assets",
                column: "Id_Sbn",
                principalTable: "SBNs",
                principalColumn: "Id_Sbn",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
