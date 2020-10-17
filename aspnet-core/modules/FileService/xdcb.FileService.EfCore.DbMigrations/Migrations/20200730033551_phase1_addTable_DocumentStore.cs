using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.FileService.EfCore.DbMigrations.Migrations
{
    public partial class phase1_addTable_DocumentStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.CreateTable(
                name: "DocumentStores",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    TenFile = table.Column<string>(nullable: true),
                    Url = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    KieuFile = table.Column<string>(maxLength: 255, nullable: false),
                    KichThuoc = table.Column<decimal>(nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    TotalPage = table.Column<decimal>(nullable: true),
                    Cached = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentStores",
                schema: "common");
        }
    }
}
