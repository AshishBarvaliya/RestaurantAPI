﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.DbContext;

namespace Restaurant.DbContext.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20200109072017_initial3")]
    partial class initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurant.Entity.CuisineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("CuisineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Rajastani"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Indian"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Italian"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Chinese"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Gujarati"
                        });
                });

            modelBuilder.Entity("Restaurant.Entity.Ratings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasMaxLength(2);

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Rating = 5,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Rating = 9,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Rating = 7,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Rating = 2,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Rating = 3,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 6,
                            Rating = 8,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 7,
                            Rating = 5,
                            RestaurantId = 4
                        });
                });

            modelBuilder.Entity("Restaurant.Entity.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lng")
                        .HasColumnType("float");

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Bangaluru",
                            Lat = 20.102,
                            Lng = 20.102,
                            Locality = "HSR",
                            Name = "Tawa Ghar",
                            Postcode = "2020",
                            State = "Karnataka",
                            Street = "1st"
                        },
                        new
                        {
                            Id = 2,
                            City = "Kota",
                            Lat = 21.102,
                            Lng = 21.102,
                            Locality = "Ganeshnagar",
                            Name = "Menal Hotel",
                            Postcode = "2121",
                            State = "Rajasthan",
                            Street = "Talwandi"
                        },
                        new
                        {
                            Id = 3,
                            City = "Surat",
                            Lat = 22.102,
                            Lng = 22.102,
                            Locality = "Kapodra",
                            Name = "Laxmi Hotel",
                            Postcode = "2222",
                            State = "Gujarat",
                            Street = "Varachha"
                        },
                        new
                        {
                            Id = 4,
                            City = "Surat",
                            Lat = 23.102,
                            Lng = 23.102,
                            Locality = "Simada",
                            Name = "Red Chilli Hotel",
                            Postcode = "2323",
                            State = "Gujarat",
                            Street = "Varachha"
                        });
                });

            modelBuilder.Entity("Restaurant.Entity.RestaurantCuisine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CuisineTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CuisineTypeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantCuisines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CuisineTypeId = 2,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            CuisineTypeId = 3,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            CuisineTypeId = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            CuisineTypeId = 3,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            CuisineTypeId = 1,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 6,
                            CuisineTypeId = 5,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 7,
                            CuisineTypeId = 1,
                            RestaurantId = 4
                        });
                });

            modelBuilder.Entity("Restaurant.Entity.Ratings", b =>
                {
                    b.HasOne("Restaurant.Entity.Restaurant", "Restaurant")
                        .WithMany("Ratings")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Restaurant.Entity.RestaurantCuisine", b =>
                {
                    b.HasOne("Restaurant.Entity.CuisineType", "CuisineType")
                        .WithMany("RestaurantCuisine")
                        .HasForeignKey("CuisineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurant.Entity.Restaurant", "Restaurant")
                        .WithMany("RestaurantCuisine")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
