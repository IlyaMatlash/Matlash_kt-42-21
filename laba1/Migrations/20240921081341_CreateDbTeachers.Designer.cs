﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using laba1.Database;

#nullable disable

namespace laba1.Migrations
{
    [DbContext(typeof(MatlashDbContext))]
    [Migration("20240921081341_CreateDbTeachers")]
    partial class CreateDbTeachers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("laba1.Models.EducationalSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasComment("Идентификатор дисциплины");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("name")
                        .HasComment("Наименование дисциплины");

                    b.HasKey("Id")
                        .HasName("pk_educationalsubject_id");

                    b.ToTable("educationalsubject", (string)null);
                });

            modelBuilder.Entity("laba1.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasComment("Идентификатор преподавателя");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("middlename")
                        .HasComment("Отчество преподавателя");

                    b.HasKey("Id")
                        .HasName("pk_professor_id");

                    b.ToTable("professor", (string)null);
                });

            modelBuilder.Entity("laba1.Models.Workload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasComment("Идентификатор нагрузки");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EducationalSubjectId")
                        .HasColumnType("int")
                        .HasColumnName("educationsubject_id")
                        .HasComment("Идентификатор дисциплины");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("int")
                        .HasColumnName("numberofhours")
                        .HasComment("Количество часов нагрузки");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int")
                        .HasColumnName("professor_id")
                        .HasComment("Идентификатор профессора");

                    b.HasKey("Id")
                        .HasName("pk_workload_id");

                    b.HasIndex("EducationalSubjectId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("workload", (string)null);
                });

            modelBuilder.Entity("laba1.Models.Workload", b =>
                {
                    b.HasOne("laba1.Models.EducationalSubject", "EducationalSubject")
                        .WithMany()
                        .HasForeignKey("EducationalSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_educationalsubject_id");

                    b.HasOne("laba1.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_professor_id");

                    b.Navigation("EducationalSubject");

                    b.Navigation("Professor");
                });
#pragma warning restore 612, 618
        }
    }
}
