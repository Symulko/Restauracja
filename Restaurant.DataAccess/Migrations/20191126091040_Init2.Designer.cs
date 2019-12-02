﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.DataAccess;

namespace Restaurant.DataAccess.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20191126091040_Init2")]
    partial class Init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurant.Model.Entities.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Restaurant.Model.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Restaurant.Model.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CommentId")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ItemsTotal")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Restaurant.Model.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Restaurant.Model.Entities.OrderItemOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("OrderItemId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductOptionId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderItemId");

                    b.HasIndex("ProductOptionId");

                    b.ToTable("OrderItemOptions");
                });

            modelBuilder.Entity("Restaurant.Model.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("PictureUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Margheritta",
                            Price = 20m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vegetariana",
                            Price = 22m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tosca",
                            Price = 25m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Venecia",
                            Price = 25m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Schabowy z frytkami",
                            Price = 30m,
                            ProductTypeId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 6,
                            Name = "Schabowy z ryzem",
                            Price = 30m,
                            ProductTypeId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 7,
                            Name = "Schabowy z ziemniakami",
                            Price = 30m,
                            ProductTypeId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ryba z frytkami",
                            Price = 28m,
                            ProductTypeId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 9,
                            Name = "Placek po węgiersku",
                            Price = 27m,
                            ProductTypeId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 10,
                            Name = "Pomidorowa",
                            Price = 12m,
                            ProductTypeId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 11,
                            Name = "Rosół",
                            Price = 10m,
                            ProductTypeId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 12,
                            Name = "Kawa",
                            Price = 5m,
                            ProductTypeId = 4,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 13,
                            Name = "Herbata",
                            Price = 5m,
                            ProductTypeId = 4,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 14,
                            Name = "Cola",
                            Price = 5m,
                            ProductTypeId = 4,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("Restaurant.Model.Entities.ProductOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductOptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Podwojny ser",
                            Price = 2m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Salami",
                            Price = 2m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Szynka",
                            Price = 2m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pieczarki",
                            Price = 2m,
                            ProductTypeId = 1,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bar salatkowy",
                            Price = 5m,
                            ProductTypeId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 6,
                            Name = "Zestaw sosow",
                            Price = 6m,
                            ProductTypeId = 2,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("Restaurant.Model.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Pizza"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Dania główne"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Zupy"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Napoje"
                        });
                });

            modelBuilder.Entity("Restaurant.Model.Entities.Order", b =>
                {
                    b.HasOne("Restaurant.Model.Entities.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Model.Entities.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Restaurant.Model.Entities.OrderItem", b =>
                {
                    b.HasOne("Restaurant.Model.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Model.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restaurant.Model.Entities.OrderItemOption", b =>
                {
                    b.HasOne("Restaurant.Model.Entities.OrderItem", "OrderItem")
                        .WithMany("OrderItemOptions")
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Model.Entities.ProductOption", "ProductOption")
                        .WithMany()
                        .HasForeignKey("ProductOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restaurant.Model.Entities.Product", b =>
                {
                    b.HasOne("Restaurant.Model.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restaurant.Model.Entities.ProductOption", b =>
                {
                    b.HasOne("Restaurant.Model.Entities.Product", null)
                        .WithMany("ProductOptions")
                        .HasForeignKey("ProductId");

                    b.HasOne("Restaurant.Model.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
