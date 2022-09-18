using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class testingv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhaSanXuat",
                columns: table => new
                {
                    IDNhaSanXuat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaNhaSanXuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenNhaSanXuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaSanXuat", x => x.IDNhaSanXuat);
                });

            migrationBuilder.CreateTable(
                name: "TestingObejct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestingObejct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    MaHangHoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenHangHoa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DonGiaNhap = table.Column<double>(type: "float", nullable: false),
                    DonGiaBan = table.Column<double>(type: "float", nullable: false),
                    IDNhaSanXuat = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.MaHangHoa);
                    table.ForeignKey(
                        name: "FK_Product_NhaSanXuat_IDNhaSanXuat",
                        column: x => x.IDNhaSanXuat,
                        principalTable: "NhaSanXuat",
                        principalColumn: "IDNhaSanXuat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDNhaSanXuat",
                table: "Product",
                column: "IDNhaSanXuat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "TestingObejct");

            migrationBuilder.DropTable(
                name: "NhaSanXuat");
        }
    }
}
