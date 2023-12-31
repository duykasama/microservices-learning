﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.Microservices.Services.CouponApi.Data;

#nullable disable

namespace NetCore.Microservices.Services.CouponApi.Migrations
{
    [DbContext(typeof(CouponDbContext))]
    [Migration("20231219191137_UpdateCouponPKName")]
    partial class UpdateCouponPKName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetCore.Microservices.Services.CouponApi.Domain.Entities.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CouponId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AuditedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("AuditedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("CouponId");

                    b.ToTable("Coupon", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
