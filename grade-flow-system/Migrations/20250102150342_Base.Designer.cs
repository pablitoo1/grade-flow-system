﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using grade_flow_system.Configuration;

#nullable disable

namespace grade_flow_system.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250102150342_Base")]
    partial class Base
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("grade_flow_system.Models.Entity.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GradeTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradeTypeId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("grade_flow_system.Models.Entity.GradeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Value")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("GradeType");
                });

            modelBuilder.Entity("grade_flow_system.Models.Entity.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("grade_flow_system.Models.Entity.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("grade_flow_system.Models.Entity.Grade", b =>
                {
                    b.HasOne("grade_flow_system.Models.Entity.GradeType", "GradeType")
                        .WithMany()
                        .HasForeignKey("GradeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("grade_flow_system.Models.Entity.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("grade_flow_system.Models.Entity.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GradeType");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("grade_flow_system.Models.Entity.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("grade_flow_system.Models.Entity.Subject", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
