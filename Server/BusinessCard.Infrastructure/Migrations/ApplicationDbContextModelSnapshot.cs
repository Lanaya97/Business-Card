﻿// <auto-generated />
using System;
using BusinessCard.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessCard.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BusinessCard.Domain.BusinessCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Photo")
                        .HasMaxLength(65535)
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("BusinessCard", (string)null);
                });

            modelBuilder.Entity("BusinessCard.Domain.BusinessCard", b =>
                {
                    b.OwnsOne("BusinessCard.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("BusinessCardId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("City");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("ZipCode");

                            b1.HasKey("BusinessCardId");

                            b1.ToTable("BusinessCard");

                            b1.WithOwner()
                                .HasForeignKey("BusinessCardId");
                        });

                    b.OwnsOne("BusinessCard.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("BusinessCardId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("CountryCode");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("BusinessCardId");

                            b1.HasIndex("Number")
                                .IsUnique();

                            b1.ToTable("BusinessCard");

                            b1.WithOwner()
                                .HasForeignKey("BusinessCardId");
                        });

                    b.Navigation("Address");

                    b.Navigation("PhoneNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
