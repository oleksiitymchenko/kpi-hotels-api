using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kpi.Hotels.Dataclient.Migrations
{
    public partial class addedserviceclassIdtoroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_ServiceClass_ServiceClassId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceClass",
                table: "ServiceClass");

            migrationBuilder.RenameTable(
                name: "ServiceClass",
                newName: "ServiceClasses");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceClassId",
                table: "Rooms",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceClasses",
                table: "ServiceClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_ServiceClasses_ServiceClassId",
                table: "Rooms",
                column: "ServiceClassId",
                principalTable: "ServiceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_ServiceClasses_ServiceClassId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceClasses",
                table: "ServiceClasses");

            migrationBuilder.RenameTable(
                name: "ServiceClasses",
                newName: "ServiceClass");

            migrationBuilder.AlterColumn<Guid>(
                name: "ServiceClassId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceClass",
                table: "ServiceClass",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_ServiceClass_ServiceClassId",
                table: "Rooms",
                column: "ServiceClassId",
                principalTable: "ServiceClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
