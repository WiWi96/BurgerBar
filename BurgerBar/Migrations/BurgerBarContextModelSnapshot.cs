﻿// <auto-generated />
using System;
using BurgerBar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BurgerBar.Migrations
{
    [DbContext(typeof(BurgerBarContext))]
    partial class BurgerBarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BurgerBar.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasMaxLength(8);

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("BurgerBar.Entities.BurgerIngredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BurgerId");

                    b.Property<long>("IngredientId");

                    b.Property<short>("Position");

                    b.HasKey("Id");

                    b.HasIndex("BurgerId");

                    b.HasIndex("IngredientId");

                    b.ToTable("BurgerIngredient");
                });

            modelBuilder.Entity("BurgerBar.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BurgerBar.Entities.DeliveryType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCOD");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("DeliveryType");
                });

            modelBuilder.Entity("BurgerBar.Entities.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Picture");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Ingredient");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Ingredient");
                });

            modelBuilder.Entity("BurgerBar.Entities.IngredientType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("IngredientType");

                    b.HasData(
                        new { Id = 1L, Name = "Meat" },
                        new { Id = 2L, Name = "Cheese" },
                        new { Id = 3L, Name = "Sauce" },
                        new { Id = 4L, Name = "Vegetable" },
                        new { Id = 5L, Name = "Spice" }
                    );
                });

            modelBuilder.Entity("BurgerBar.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CustomerId");

                    b.Property<long>("DeliveryTypeId");

                    b.Property<long>("PaymentTypeId");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BurgerBar.Entities.OrderedProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("OrderId");

                    b.Property<long>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderedProduct");
                });

            modelBuilder.Entity("BurgerBar.Entities.PaymentType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCOD");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("BurgerBar.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsInMenu");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Product");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("BurgerBar.Entities.ProductType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new { Id = 1L, Name = "Appetizers" },
                        new { Id = 2L, Name = "Soup" },
                        new { Id = 3L, Name = "Main courses" },
                        new { Id = 4L, Name = "Salads" },
                        new { Id = 5L, Name = "Desserts" },
                        new { Id = 6L, Name = "Beverages" }
                    );
                });

            modelBuilder.Entity("BurgerBar.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BurgerBar.Entities.Bun", b =>
                {
                    b.HasBaseType("BurgerBar.Entities.Ingredient");

                    b.Property<string>("BottomPicture");

                    b.Property<string>("TopPicture");

                    b.ToTable("Bun");

                    b.HasDiscriminator().HasValue("Bun");
                });

            modelBuilder.Entity("BurgerBar.Entities.Burger", b =>
                {
                    b.HasBaseType("BurgerBar.Entities.Product");

                    b.Property<long?>("BunId");

                    b.Property<int>("CreationType");

                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("");

                    b.HasIndex("BunId");

                    b.ToTable("Burger");

                    b.HasDiscriminator().HasValue("Burger");
                });

            modelBuilder.Entity("BurgerBar.Entities.BurgerIngredient", b =>
                {
                    b.HasOne("BurgerBar.Entities.Burger")
                        .WithMany("Ingredients")
                        .HasForeignKey("BurgerId");

                    b.HasOne("BurgerBar.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BurgerBar.Entities.Customer", b =>
                {
                    b.HasOne("BurgerBar.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("BurgerBar.Entities.Ingredient", b =>
                {
                    b.HasOne("BurgerBar.Entities.IngredientType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BurgerBar.Entities.Order", b =>
                {
                    b.HasOne("BurgerBar.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BurgerBar.Entities.DeliveryType", "DeliveryType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BurgerBar.Entities.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BurgerBar.Entities.OrderedProduct", b =>
                {
                    b.HasOne("BurgerBar.Entities.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("BurgerBar.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BurgerBar.Entities.Product", b =>
                {
                    b.HasOne("BurgerBar.Entities.ProductType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BurgerBar.Entities.Burger", b =>
                {
                    b.HasOne("BurgerBar.Entities.Bun", "Bun")
                        .WithMany()
                        .HasForeignKey("BunId");
                });
#pragma warning restore 612, 618
        }
    }
}
