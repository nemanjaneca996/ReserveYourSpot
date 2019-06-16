using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class DeletedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocaleTables_Tables_TableId",
                table: "LocaleTables");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_LocaleTables_TableId",
                table: "LocaleTables");

            migrationBuilder.RenameColumn(
                name: "TableId",
                table: "LocaleTables",
                newName: "NumberOfSeats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfSeats",
                table: "LocaleTables",
                newName: "TableId");

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsDeleted", "ModifiedAt", "NumberOfSeats" },
                values: new object[] { 1, false, null, 1 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsDeleted", "ModifiedAt", "NumberOfSeats" },
                values: new object[] { 2, false, null, 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsDeleted", "ModifiedAt", "NumberOfSeats" },
                values: new object[] { 3, false, null, 3 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsDeleted", "ModifiedAt", "NumberOfSeats" },
                values: new object[] { 4, false, null, 4 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsDeleted", "ModifiedAt", "NumberOfSeats" },
                values: new object[] { 5, false, null, 5 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsDeleted", "ModifiedAt", "NumberOfSeats" },
                values: new object[] { 6, false, null, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_LocaleTables_TableId",
                table: "LocaleTables",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocaleTables_Tables_TableId",
                table: "LocaleTables",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
