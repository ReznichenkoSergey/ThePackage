﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThePackage.Models.Database;

namespace ThePackage.Migrations
{
    [DbContext(typeof(PackageDbContext))]
    [Migration("20200430130545_D")]
    partial class D
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThePackage.Models.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateInsert");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ThePackage.Models.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientReceiverId");

                    b.Property<int?>("ClientSenderId");

                    b.Property<DateTime>("DateInsert")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("PointDestinationId");

                    b.Property<int?>("PointSourceId");

                    b.Property<int>("StatusId");

                    b.Property<decimal>("SumDeliver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("SumPayed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("ClientReceiverId");

                    b.HasIndex("ClientSenderId");

                    b.HasIndex("PointDestinationId");

                    b.HasIndex("PointSourceId");

                    b.HasIndex("StatusId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("ThePackage.Models.Entities.PackageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("PackageType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Техника"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Канцелярия"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Стекло"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Авто. детали"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Одежда"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Мебель"
                        });
                });

            modelBuilder.Entity("ThePackage.Models.Entities.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("ThePackage.Models.Entities.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UnitsId");

                    b.HasKey("Id");

                    b.HasIndex("UnitsId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ThePackage.Models.Entities.StaffToPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PointId")
                        .IsRequired();

                    b.Property<int?>("StaffId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffToPoint");
                });

            modelBuilder.Entity("ThePackage.Models.Entities.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "К отправке",
                            TypeId = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Отправлена",
                            TypeId = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Получена на склад",
                            TypeId = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Возврат",
                            TypeId = 0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Выдана",
                            TypeId = 0
                        },
                        new
                        {
                            Id = 10,
                            Name = "Менеджер",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 11,
                            Name = "Кассир",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 12,
                            Name = "Кладовщик",
                            TypeId = 1
                        });
                });

            modelBuilder.Entity("ThePackage.Models.Entities.Package", b =>
                {
                    b.HasOne("ThePackage.Models.Entities.Client", "ClientReceiver")
                        .WithMany()
                        .HasForeignKey("ClientReceiverId");

                    b.HasOne("ThePackage.Models.Entities.Client", "ClientSender")
                        .WithMany()
                        .HasForeignKey("ClientSenderId");

                    b.HasOne("ThePackage.Models.Entities.Point", "PointDestination")
                        .WithMany()
                        .HasForeignKey("PointDestinationId");

                    b.HasOne("ThePackage.Models.Entities.Point", "PointSource")
                        .WithMany()
                        .HasForeignKey("PointSourceId");

                    b.HasOne("ThePackage.Models.Entities.Units", "Units")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ThePackage.Models.Entities.Staff", b =>
                {
                    b.HasOne("ThePackage.Models.Entities.Units", "Units")
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ThePackage.Models.Entities.StaffToPoint", b =>
                {
                    b.HasOne("ThePackage.Models.Entities.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ThePackage.Models.Entities.Staff", "Staff")
                        .WithMany("StaffToPoint")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
