using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_TransferWebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInformation",
                columns: table => new
                {
                    EmployeeCode = table.Column<int>(nullable: false),
                    CcCode = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    DateOfTransfer = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    EmployeeEmailId = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    LocalCSO = table.Column<string>(nullable: true),
                    LocalHR = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Oucode = table.Column<string>(nullable: true),
                    Supervisor = table.Column<int>(nullable: false),
                    SupervisorEmailId = table.Column<string>(nullable: true),
                    pacode = table.Column<string>(nullable: true),
                    psacode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformation", x => x.EmployeeCode);
                });

            migrationBuilder.CreateTable(
                name: "AssetsInformation",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetCode = table.Column<int>(nullable: false),
                    AssetStatus = table.Column<int>(nullable: false),
                    AssignToEmailId = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<int>(nullable: false),
                    CapitalisationDate = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployeeCode = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsInformation", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_AssetsInformation_EmployeeInformation_EmployeeCode",
                        column: x => x.EmployeeCode,
                        principalTable: "EmployeeInformation",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestsInformation",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    EmployeeCode = table.Column<int>(nullable: false),
                    NewCcCode = table.Column<string>(nullable: true),
                    NewOucode = table.Column<string>(nullable: true),
                    Newpacode = table.Column<string>(nullable: true),
                    Newpsacode = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<int>(nullable: false),
                    SupervisorCode = table.Column<int>(nullable: false),
                    TypeOfRequest = table.Column<string>(nullable: true),
                    pendingWith = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsInformation", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_RequestsInformation_EmployeeInformation_EmployeeCode",
                        column: x => x.EmployeeCode,
                        principalTable: "EmployeeInformation",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetsInformation_EmployeeCode",
                table: "AssetsInformation",
                column: "EmployeeCode");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsInformation_EmployeeCode",
                table: "RequestsInformation",
                column: "EmployeeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetsInformation");

            migrationBuilder.DropTable(
                name: "RequestsInformation");

            migrationBuilder.DropTable(
                name: "EmployeeInformation");
        }
    }
}
