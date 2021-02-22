﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationshipsMVC.Models;

namespace RelationshipsMVC.Migrations
{
    [DbContext(typeof(RelationshipDb))]
    [Migration("20210221153045_AddEmployeeProjectTable")]
    partial class AddEmployeeProjectTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RelationshipsMVC.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DeptName = "HR"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DeptName = "Sales"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DeptName = "Software Developement"
                        });
                });

            modelBuilder.Entity("RelationshipsMVC.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Ename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DepartmentId = 1,
                            Ename = "Ram"
                        },
                        new
                        {
                            EmployeeId = 2,
                            DepartmentId = 2,
                            Ename = "Shiv"
                        },
                        new
                        {
                            EmployeeId = 3,
                            DepartmentId = 2,
                            Ename = "Krishna"
                        });
                });

            modelBuilder.Entity("RelationshipsMVC.Models.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            ProjectId = 1
                        },
                        new
                        {
                            EmployeeId = 1,
                            ProjectId = 2
                        },
                        new
                        {
                            EmployeeId = 2,
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("RelationshipsMVC.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Pname = "Employee Management"
                        },
                        new
                        {
                            ProjectId = 2,
                            Pname = "Student Management"
                        });
                });

            modelBuilder.Entity("RelationshipsMVC.Models.Employee", b =>
                {
                    b.HasOne("RelationshipsMVC.Models.Department", "Departments")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RelationshipsMVC.Models.EmployeeProject", b =>
                {
                    b.HasOne("RelationshipsMVC.Models.Employee", "Employees")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RelationshipsMVC.Models.Project", "Projects")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
