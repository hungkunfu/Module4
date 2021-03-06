﻿// <auto-generated />
using EmployeeMangement.Dbcontexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeMangement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210225071939_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeMangement.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AvatarPath")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Age = 18,
                            AvatarPath = "avatar11.jpg",
                            Code = "CGH00001",
                            Email = "khoa.nguyen@codegym.vn",
                            FirstName = "Khoa",
                            LastName = "Nguyen"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Age = 18,
                            AvatarPath = "avatar10.jpg",
                            Code = "CGH00002",
                            Email = "hung.tran@codegym.vn",
                            FirstName = "Hung",
                            LastName = "Tran"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Age = 18,
                            AvatarPath = "avatar14.jpg",
                            Code = "CGH00003",
                            Email = "huy.phan@codegym.vn",
                            FirstName = "Huy",
                            LastName = "Phan"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
