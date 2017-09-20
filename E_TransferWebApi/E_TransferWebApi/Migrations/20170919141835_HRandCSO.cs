using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_TransferWebApi.Migrations
{
    public partial class HRandCSO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupervisorName",
                table: "EmployeeInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupervisorName",
                table: "EmployeeInformation");
        }
    }
}
