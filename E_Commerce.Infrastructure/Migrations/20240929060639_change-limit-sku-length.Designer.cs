﻿// <auto-generated />
using System;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240929060639_change-limit-sku-length")]
    partial class changelimitskulength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce.Domain.Entities.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.CategoryAttributes", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "AttributeId");

                    b.HasIndex("AttributeId");

                    b.ToTable("CategoryAttributes");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModifiedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.ProductVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("Sku")
                        .IsUnique();

                    b.ToTable("ProductsVariants");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.ProductVariantAttributes", b =>
                {
                    b.Property<Guid>("ProductVariantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductVariantId", "AttributeId");

                    b.HasIndex("AttributeId");

                    b.ToTable("ProductVariantAttributes");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Category", b =>
                {
                    b.HasOne("E_Commerce.Domain.Entities.Category", "Parent")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.CategoryAttributes", b =>
                {
                    b.HasOne("E_Commerce.Domain.Entities.Attribute", "Attribute")
                        .WithMany("AttributeCategories")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Domain.Entities.Category", "Category")
                        .WithMany("CategoryAttributes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Product", b =>
                {
                    b.HasOne("E_Commerce.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.ProductVariant", b =>
                {
                    b.HasOne("E_Commerce.Domain.Entities.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.ProductVariantAttributes", b =>
                {
                    b.HasOne("E_Commerce.Domain.Entities.Attribute", "Attribute")
                        .WithMany("ProductVariantsAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Domain.Entities.ProductVariant", "ProductVariant")
                        .WithMany("ProductVariantAttributes")
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Attribute", b =>
                {
                    b.Navigation("AttributeCategories");

                    b.Navigation("ProductVariantsAttributes");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Category", b =>
                {
                    b.Navigation("CategoryAttributes");

                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("E_Commerce.Domain.Entities.ProductVariant", b =>
                {
                    b.Navigation("ProductVariantAttributes");
                });
#pragma warning restore 612, 618
        }
    }
}
