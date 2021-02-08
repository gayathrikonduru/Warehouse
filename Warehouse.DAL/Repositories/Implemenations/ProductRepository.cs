using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL.Models;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.DAL.Repositories.Implemenations
{
    public class ProductRepository : IProductRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public ProductRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }
        public int AddNewProduct(Product product)
        {
            _warehouseDbContext.Products.Add(product);

            var response = _warehouseDbContext.SaveChanges();

            return product.ProductId;
        }

        public int? DeleteProduct(int productId)
        {
            var productToDelete = _warehouseDbContext.Products.Where(product => product.ProductId == productId && !product.IsDeleted).FirstOrDefault();
            if (productToDelete == null)
            {
                return null;
            }

            productToDelete.IsDeleted = true;
            return _warehouseDbContext.SaveChanges();
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            var products = await _warehouseDbContext.Products
                                              .Include(product => product.UsedArticles)
                                                 .ThenInclude(usedArticle => usedArticle.Article)
                                              .Where(product => !product.IsDeleted).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _warehouseDbContext.Products
                                      .Include(p => p.UsedArticles)
                                            .ThenInclude(usedArticle => usedArticle.Article)
                                      .FirstOrDefaultAsync(p => p.ProductId == productId && !p.IsDeleted);
        }

        public int? UpdateProduct(Product product)
        {

            var productToUpdate = _warehouseDbContext.Products
                                                 .Include(p => p.UsedArticles)
                                                 .FirstOrDefault(p => p.ProductId == product.ProductId && !p.IsDeleted);
            if (productToUpdate == null)
            {
                return null;
            }
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductPrice = product.ProductPrice;
            productToUpdate.UsedArticles = product.UsedArticles;
            return _warehouseDbContext.SaveChanges();

        }
    }
}
