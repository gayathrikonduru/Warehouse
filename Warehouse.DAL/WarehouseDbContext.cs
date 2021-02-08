using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DAL.Models;

namespace Warehouse.DAL
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext() { }
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options): base(options) { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ProductArticle> ProductArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<ProductArticle>().ToTable("ProductArticle");

        }

    }
}
