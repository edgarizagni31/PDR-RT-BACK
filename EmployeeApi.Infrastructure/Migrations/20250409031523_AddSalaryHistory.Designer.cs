﻿// <auto-generated />
using System;
using EmployeeApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeApi.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20250409031523_AddSalaryHistory")]
    partial class AddSalaryHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeApi.Domain.Entities.AFP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Afps");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AfpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("AfpId");

                    b.HasIndex("JobId");

                    b.ToTable("Employees", null, t =>
                        {
                            t.HasTrigger("Salary_Update");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeparmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeparmentId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.SalaryHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("NewSalary")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("OldSalary")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SalaryHistory");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Employee", b =>
                {
                    b.HasOne("EmployeeApi.Domain.Entities.AFP", "Afp")
                        .WithMany("Employees")
                        .HasForeignKey("AfpId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EmployeeApi.Domain.Entities.Job", "Job")
                        .WithMany("Employees")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Afp");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Job", b =>
                {
                    b.HasOne("EmployeeApi.Domain.Entities.Department", "Deparment")
                        .WithMany("Jobs")
                        .HasForeignKey("DeparmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deparment");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.SalaryHistory", b =>
                {
                    b.HasOne("EmployeeApi.Domain.Entities.Employee", "Employee")
                        .WithMany("SalaryHistories")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.AFP", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Department", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Employee", b =>
                {
                    b.Navigation("SalaryHistories");
                });

            modelBuilder.Entity("EmployeeApi.Domain.Entities.Job", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
