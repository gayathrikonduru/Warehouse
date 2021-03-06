﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.DAL;

namespace Warehouse.DAL.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    partial class WarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Warehouse.DAL.Models.Article", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<string>("ArticleName");

                    b.Property<int>("ArticleStock");

                    b.HasKey("ArticleId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Warehouse.DAL.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ProductName");

                    b.Property<decimal>("ProductPrice");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Warehouse.DAL.Models.ProductArticle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<int>("ArticleQuantity");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductArticle");
                });

            modelBuilder.Entity("Warehouse.DAL.Models.ProductArticle", b =>
                {
                    b.HasOne("Warehouse.DAL.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Warehouse.DAL.Models.Product", "Product")
                        .WithMany("UsedArticles")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
