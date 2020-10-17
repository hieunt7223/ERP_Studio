using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.Common.EfCore.DbMigrations.Migrations
{
    public partial class phase3_updateTable_loaihoso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoThanhPhanHoSos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianXuLyQuyDinhNhomC",
                schema: "common",
                table: "LoaiHoSos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianXuLyQuyDinhNhomB",
                schema: "common",
                table: "LoaiHoSos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianXuLyQuyDinhNhomA",
                schema: "common",
                table: "LoaiHoSos",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoCoSoPhapLys",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "common",
                table: "LoaiHoSoChiPhiDauTus",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianXuLyQuyDinhNhomC",
                schema: "common",
                table: "LoaiHoSos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianXuLyQuyDinhNhomB",
                schema: "common",
                table: "LoaiHoSos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianXuLyQuyDinhNhomA",
                schema: "common",
                table: "LoaiHoSos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
