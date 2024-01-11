﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OOP;

#nullable disable

namespace OOP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OOP.Client", b =>
                {
                    b.Property<int>("Client_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("contact_information")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("contract")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Client_id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("OOP.Department", b =>
                {
                    b.Property<int>("department_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("department_id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("OOP.Domain.Entity.Employee", b =>
                {
                    b.Property<int>("employee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal?>("salary")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("employee_id");

                    b.HasIndex("departmentId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("OOP.EmployeeInProject", b =>
                {
                    b.Property<int>("assignment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProjectRolerole_id")
                        .HasColumnType("int");

                    b.Property<int>("employee_id")
                        .HasColumnType("int");

                    b.Property<int>("employee_id1")
                        .HasColumnType("int");

                    b.Property<int>("project_id")
                        .HasColumnType("int");

                    b.Property<int>("project_id1")
                        .HasColumnType("int");

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.HasKey("assignment_id");

                    b.HasIndex("ProjectRolerole_id");

                    b.HasIndex("employee_id1");

                    b.HasIndex("project_id1");

                    b.ToTable("employeesInProject");
                });

            modelBuilder.Entity("OOP.MediaResource", b =>
                {
                    b.Property<int>("resource_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("resource_id");

                    b.HasIndex("projectId");

                    b.ToTable("mediaResources");
                });

            modelBuilder.Entity("OOP.Orders", b =>
                {
                    b.Property<int>("Order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Client_id")
                        .HasColumnType("int");

                    b.Property<decimal?>("amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Order_id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("OOP.Project", b =>
                {
                    b.Property<int>("project_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Order_id")
                        .HasColumnType("int");

                    b.Property<string>("description_")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("end_date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("start_date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("status_")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("project_id");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("OOP.ProjectRole", b =>
                {
                    b.Property<int>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("role_id");

                    b.ToTable("projectRoles");
                });

            modelBuilder.Entity("OOP.Domain.Entity.Employee", b =>
                {
                    b.HasOne("OOP.Department", "department")
                        .WithMany()
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("OOP.EmployeeInProject", b =>
                {
                    b.HasOne("OOP.ProjectRole", "ProjectRole")
                        .WithMany()
                        .HasForeignKey("ProjectRolerole_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OOP.Domain.Entity.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employee_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OOP.Project", "project")
                        .WithMany()
                        .HasForeignKey("project_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectRole");

                    b.Navigation("employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("OOP.MediaResource", b =>
                {
                    b.HasOne("OOP.Project", "Project")
                        .WithMany()
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
