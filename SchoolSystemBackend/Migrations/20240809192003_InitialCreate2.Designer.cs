﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSystemBackend.Data;

#nullable disable

namespace SchoolSystemBackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240809192003_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolSystemBackend.Models.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SchoolSystemBackend.Models.Entities.NextOfKin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NextOfKins");
                });

            modelBuilder.Entity("SchoolSystemBackend.Models.Entities.Staff", b =>
                {
                    b.HasBaseType("SchoolSystemBackend.Models.Entities.AppUser");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EntranceDate")
                        .HasColumnType("date");

                    b.Property<int>("NationalId")
                        .HasColumnType("int");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("SchoolSystemBackend.Models.Entities.Student", b =>
                {
                    b.HasBaseType("SchoolSystemBackend.Models.Entities.AppUser");

                    b.Property<DateOnly>("AdmissionDate")
                        .HasColumnType("date");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("SchoolSystemBackend.Models.Entities.Staff", b =>
                {
                    b.HasOne("SchoolSystemBackend.Models.Entities.AppUser", null)
                        .WithOne()
                        .HasForeignKey("SchoolSystemBackend.Models.Entities.Staff", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolSystemBackend.Models.Entities.Student", b =>
                {
                    b.HasOne("SchoolSystemBackend.Models.Entities.AppUser", null)
                        .WithOne()
                        .HasForeignKey("SchoolSystemBackend.Models.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
