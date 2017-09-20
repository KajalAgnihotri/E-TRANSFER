using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using E_TransferWebApi.Models;

namespace E_TransferWebApi.Migrations
{
    [DbContext(typeof(ETransferDbContext))]
    partial class ETransferDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_TransferWebApi.Models.AssetDetails", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssetCode");

                    b.Property<int>("AssetStatus");

                    b.Property<string>("AssignToEmailId");

                    b.Property<int>("AssignedTo");

                    b.Property<string>("CapitalisationDate");

                    b.Property<string>("CompanyCode");

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeCode");

                    b.Property<string>("Location");

                    b.Property<int>("Quantity");

                    b.HasKey("AssetId");

                    b.HasIndex("EmployeeCode");

                    b.ToTable("AssetsInformation");
                });

            modelBuilder.Entity("E_TransferWebApi.Models.EmployeeDetails", b =>
                {
                    b.Property<int>("EmployeeCode");

                    b.Property<string>("CcCode");

                    b.Property<string>("CompanyCode");

                    b.Property<DateTime>("DateOfTransfer");

                    b.Property<string>("Designation");

                    b.Property<string>("EmployeeEmailId");

                    b.Property<string>("EmployeeName");

                    b.Property<string>("LocalCSO");

                    b.Property<string>("LocalHR");

                    b.Property<string>("Location");

                    b.Property<string>("Oucode");

                    b.Property<int>("Supervisor");

                    b.Property<string>("SupervisorEmailId");

                    b.Property<string>("SupervisorName");

                    b.Property<string>("pacode");

                    b.Property<string>("psacode");

                    b.HasKey("EmployeeCode");

                    b.ToTable("EmployeeInformation");
                });

            modelBuilder.Entity("E_TransferWebApi.Models.RequestDetails", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfRequest");

                    b.Property<int>("EmployeeCode");

                    b.Property<string>("NewCcCode");

                    b.Property<string>("NewOucode");

                    b.Property<string>("Newpacode");

                    b.Property<string>("Newpsacode");

                    b.Property<int>("RequestStatus");

                    b.Property<int>("SupervisorCode");

                    b.Property<string>("TypeOfRequest");

                    b.Property<int>("pendingWith");

                    b.HasKey("RequestId");

                    b.HasIndex("EmployeeCode");

                    b.ToTable("RequestsInformation");
                });

            modelBuilder.Entity("E_TransferWebApi.Models.AssetDetails", b =>
                {
                    b.HasOne("E_TransferWebApi.Models.EmployeeDetails", "EmployeeDetails")
                        .WithMany("AssetList")
                        .HasForeignKey("EmployeeCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("E_TransferWebApi.Models.RequestDetails", b =>
                {
                    b.HasOne("E_TransferWebApi.Models.EmployeeDetails", "EmployeeDetails")
                        .WithMany()
                        .HasForeignKey("EmployeeCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
