using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class alter_table_loaihoso_change_baseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
