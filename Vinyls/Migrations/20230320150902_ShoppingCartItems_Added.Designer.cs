﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vinyls.Data;

namespace Vinyls.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230320150902_ShoppingCartItems_Added")]
    partial class ShoppingCartItems_Added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vinyls.Models.AlbumGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlbumGenres");
                });

            modelBuilder.Entity("Vinyls.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Vinyls.Models.Artist_Vinyl", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("VinylId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "VinylId");

                    b.HasIndex("VinylId");

                    b.ToTable("Artists_Vinyls");
                });

            modelBuilder.Entity("Vinyls.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Vinyls.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("VinylId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("VinylId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Vinyls.Models.RecordLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecordLabels");
                });

            modelBuilder.Entity("Vinyls.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VinylId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VinylId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Vinyls.Models.Vinyl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumFormat")
                        .HasColumnType("int");

                    b.Property<int>("AlbumGenreId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RecordLabelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumGenreId");

                    b.HasIndex("RecordLabelId");

                    b.ToTable("Vinyls");
                });

            modelBuilder.Entity("Vinyls.Models.Artist_Vinyl", b =>
                {
                    b.HasOne("Vinyls.Models.Artist", "Artist")
                        .WithMany("Artist_Vinyls")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vinyls.Models.Vinyl", "Vinyl")
                        .WithMany("Artist_Vinyls")
                        .HasForeignKey("VinylId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Vinyl");
                });

            modelBuilder.Entity("Vinyls.Models.OrderItem", b =>
                {
                    b.HasOne("Vinyls.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vinyls.Models.Vinyl", "Vinyl")
                        .WithMany()
                        .HasForeignKey("VinylId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Vinyl");
                });

            modelBuilder.Entity("Vinyls.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("Vinyls.Models.Vinyl", "Vinyl")
                        .WithMany()
                        .HasForeignKey("VinylId");

                    b.Navigation("Vinyl");
                });

            modelBuilder.Entity("Vinyls.Models.Vinyl", b =>
                {
                    b.HasOne("Vinyls.Models.AlbumGenre", "AlbumGenre")
                        .WithMany("Vinyls")
                        .HasForeignKey("AlbumGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vinyls.Models.RecordLabel", "RecordLabel")
                        .WithMany("Vinyls")
                        .HasForeignKey("RecordLabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlbumGenre");

                    b.Navigation("RecordLabel");
                });

            modelBuilder.Entity("Vinyls.Models.AlbumGenre", b =>
                {
                    b.Navigation("Vinyls");
                });

            modelBuilder.Entity("Vinyls.Models.Artist", b =>
                {
                    b.Navigation("Artist_Vinyls");
                });

            modelBuilder.Entity("Vinyls.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Vinyls.Models.RecordLabel", b =>
                {
                    b.Navigation("Vinyls");
                });

            modelBuilder.Entity("Vinyls.Models.Vinyl", b =>
                {
                    b.Navigation("Artist_Vinyls");
                });
#pragma warning restore 612, 618
        }
    }
}
