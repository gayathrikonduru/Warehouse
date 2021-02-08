using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.BLL.Interfaces;
using Warehouse.Common.Models;
using Warehouse.DAL.Repositories.Interfaces;
using Warehouse.DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.BLL.Implementations
{
    public class ImportDataService : IImportDataService
    {
        private readonly IImportDataRepository _importDataRepository;

        public ImportDataService(IImportDataRepository importDataRepository)
        {
            _importDataRepository = importDataRepository;
        }       
        public void ImportArticlesData(List<Common.Models.Article> articlesList)
        {
            if(articlesList != null)
            {
                var articlesRepoData = articlesList.Select(article => new DAL.Models.Article
                {
                    ArticleId = article.ArticleId,
                    ArticleName = article.Name,
                    ArticleStock = article.Stock
                }).ToList();
                _importDataRepository.ImportArticlesData(articlesRepoData);
            }           
        }
        public void ImportProductsData(List<Common.Models.Product> productsList)
        {
            if(productsList != null)
            {
                var productsRepoData = productsList.Select(product => new DAL.Models.Product
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    UsedArticles = product.ContainArticles.Select(article => new DAL.Models.ProductArticle
                    {
                        ArticleId = article.ArticleId,
                        ArticleQuantity = article.AmountOf
                    }).ToList()

                });
                _importDataRepository.ImportProductsData(productsRepoData.ToList());
            }            
        }
    }
}
