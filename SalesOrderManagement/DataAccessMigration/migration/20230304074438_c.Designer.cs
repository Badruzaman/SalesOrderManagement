﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesOrderManagement.Api.Data;

#nullable disable

namespace SalesOrderManagement.Api.DataAccessMigration.migration
{
    [DbContext(typeof(SalesOrderDBContext))]
    [Migration("20230304074438_c")]
    partial class c
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("BuildingId");

                    b.HasIndex("StateId");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.Dimension", b =>
                {
                    b.Property<int>("DimensionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DimensionId"));

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Width")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DimensionId");

                    b.ToTable("Dimension");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.ProductAttribute", b =>
                {
                    b.Property<int>("ProductAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductAttributeId"));

                    b.Property<int>("DimensionId")
                        .HasColumnType("int");

                    b.Property<string>("ProductAttributeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductAttributeId");

                    b.HasIndex("DimensionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttribute");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.SalesOrder", b =>
                {
                    b.Property<long>("SalesOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SalesOrderId"));

                    b.Property<int>("BuildingsId")
                        .HasColumnType("int");

                    b.Property<int>("StatesId")
                        .HasColumnType("int");

                    b.HasKey("SalesOrderId");

                    b.HasIndex("BuildingsId");

                    b.HasIndex("StatesId");

                    b.ToTable("SalesOrder");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.SalesOrderDetail", b =>
                {
                    b.Property<long>("SalesOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SalesOrderDetailId"));

                    b.Property<int>("ProductAttributeId")
                        .HasColumnType("int");

                    b.Property<decimal>("QuantityOfWindows")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SalesOrderId")
                        .HasColumnType("bigint");

                    b.HasKey("SalesOrderDetailId");

                    b.HasIndex("ProductAttributeId");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderDetail");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StateId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.Building", b =>
                {
                    b.HasOne("SalesOrderManagement.Api.Entities.State", "State")
                        .WithMany("Building")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.ProductAttribute", b =>
                {
                    b.HasOne("SalesOrderManagement.Api.Entities.Dimension", "Dimension")
                        .WithMany()
                        .HasForeignKey("DimensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesOrderManagement.Api.Entities.Product", "Product")
                        .WithMany("ProductAttribute")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dimension");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.SalesOrder", b =>
                {
                    b.HasOne("SalesOrderManagement.Api.Entities.Building", "Buildings")
                        .WithMany()
                        .HasForeignKey("BuildingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesOrderManagement.Api.Entities.State", "States")
                        .WithMany()
                        .HasForeignKey("StatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buildings");

                    b.Navigation("States");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.SalesOrderDetail", b =>
                {
                    b.HasOne("SalesOrderManagement.Api.Entities.ProductAttribute", "ProductAttribute")
                        .WithMany()
                        .HasForeignKey("ProductAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesOrderManagement.Api.Entities.SalesOrder", "SalesOrder")
                        .WithMany("SalesOrderDetail")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductAttribute");

                    b.Navigation("SalesOrder");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.Product", b =>
                {
                    b.Navigation("ProductAttribute");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.SalesOrder", b =>
                {
                    b.Navigation("SalesOrderDetail");
                });

            modelBuilder.Entity("SalesOrderManagement.Api.Entities.State", b =>
                {
                    b.Navigation("Building");
                });
#pragma warning restore 612, 618
        }
    }
}