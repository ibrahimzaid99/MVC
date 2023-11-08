﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Mvc.Models;

#nullable disable

namespace Project_Mvc.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20230917204712_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project_Mvc.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("MinimumDegree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Project_Mvc.Models.CourseResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("Trainee_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Crs_Id");

                    b.HasIndex("Trainee_Id");

                    b.ToTable("CourseResults");
                });

            modelBuilder.Entity("Project_Mvc.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Project_Mvc.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Crs_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Project_Mvc.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("Project_Mvc.Models.Course", b =>
                {
                    b.HasOne("Project_Mvc.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Project_Mvc.Models.CourseResult", b =>
                {
                    b.HasOne("Project_Mvc.Models.Course", "Course")
                        .WithMany("Courses")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Mvc.Models.Trainee", "Trainee")
                        .WithMany("Results")
                        .HasForeignKey("Trainee_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Project_Mvc.Models.Instructor", b =>
                {
                    b.HasOne("Project_Mvc.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("Crs_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Mvc.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Project_Mvc.Models.Trainee", b =>
                {
                    b.HasOne("Project_Mvc.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Project_Mvc.Models.Course", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Project_Mvc.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("Project_Mvc.Models.Trainee", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
