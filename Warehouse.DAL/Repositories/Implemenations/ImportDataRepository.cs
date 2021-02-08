using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL.Repositories.Interfaces;
using Warehouse.DAL.Models;

namespace Warehouse.DAL.Repositories.Implemenations
{
    public class ImportDataRepository : IImportDataRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;
        public ImportDataRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public void ImportArticlesData(List<Article> articles)
        {
            if(articles.Count > 0)
            {
                _warehouseDbContext.Articles.AddRange(articles);
                _warehouseDbContext.SaveChanges();
            }                         
        }

        public void ImportProductsData(List<Product> products)
        {            
            if (products.Count > 0)
            {
                _warehouseDbContext.Products.AddRange(products);
                _warehouseDbContext.SaveChanges();
            }                                   
        }
    }
}
