using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiData.Migrations
{
    /// <inheritdoc />
    public partial class AddedInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Cars_CarVIN",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_TaxiDepartments_TaxiDepartmentID",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drivers_DriverID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Drivers_DriverID",
                table: "WorkShifts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_TaxiDepartmentID",
                table: "Persons",
                newName: "IX_Persons_TaxiDepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_CarVIN",
                table: "Persons",
                newName: "IX_Persons_CarVIN");

            migrationBuilder.AlterColumn<int>(
                name: "TaxiDepartmentID",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TaxNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Persons",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Persons",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "CarVIN",
                table: "Persons",
                type: "nvarchar(17)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Persons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_ClientID",
                table: "Orders",
                column: "ClientID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_DriverID",
                table: "Orders",
                column: "DriverID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Cars_CarVIN",
                table: "Persons",
                column: "CarVIN",
                principalTable: "Cars",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_TaxiDepartments_TaxiDepartmentID",
                table: "Persons",
                column: "TaxiDepartmentID",
                principalTable: "TaxiDepartments",
                principalColumn: "TaxiDepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_Persons_DriverID",
                table: "WorkShifts",
                column: "DriverID",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_ClientID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_DriverID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Cars_CarVIN",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_TaxiDepartments_TaxiDepartmentID",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkShifts_Persons_DriverID",
                table: "WorkShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Drivers");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_TaxiDepartmentID",
                table: "Drivers",
                newName: "IX_Drivers_TaxiDepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CarVIN",
                table: "Drivers",
                newName: "IX_Drivers_CarVIN");

            migrationBuilder.AlterColumn<int>(
                name: "TaxiDepartmentID",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxNumber",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Drivers",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Drivers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarVIN",
                table: "Drivers",
                type: "nvarchar(17)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Cars_CarVIN",
                table: "Drivers",
                column: "CarVIN",
                principalTable: "Cars",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_TaxiDepartments_TaxiDepartmentID",
                table: "Drivers",
                column: "TaxiDepartmentID",
                principalTable: "TaxiDepartments",
                principalColumn: "TaxiDepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientID",
                table: "Orders",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drivers_DriverID",
                table: "Orders",
                column: "DriverID",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkShifts_Drivers_DriverID",
                table: "WorkShifts",
                column: "DriverID",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
