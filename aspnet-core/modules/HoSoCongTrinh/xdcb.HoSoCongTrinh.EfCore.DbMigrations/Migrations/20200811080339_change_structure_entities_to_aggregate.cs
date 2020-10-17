using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.HoSoCongTrinh.Migrations
{
    public partial class change_structure_entities_to_aggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietThanhPhanHoSoFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTiets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietNoiDungYeuCaus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietMucDauTus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietLoaiGoiThaus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietKetQuaThamDinhs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThaus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietGoiThauFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietDiaDiems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "OrderIndex",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "hsct",
                table: "HoSoCongTrinhChiTietCoSoPhapLys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
