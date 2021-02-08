using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.BLL.Interfaces;
using Warehouse.Common.Models;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.BLL.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int AddNewProduct(Product product)
        {
            var productRepo = new Warehouse.DAL.Models.Product
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                ProductPrice = product.Price,
                UsedArticles = product.ContainArticles.Select(article => new DAL.Models.ProductArticle
                {
                    ArticleId = article.ArticleId,
                    ArticleQuantity = article.AmountOf
                }).ToList()
            };
            return _productRepository.AddNewProduct(productRepo);
        }

        public int? DeleteProduct(int productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public async Task<IList<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products?.Select(product => new Common.Models.Product
            {
                ProductId = product.ProductId,
                Price = product.ProductPrice,
                Name = product.ProductName,
                ContainArticles = product.UsedArticles.Select(usedArticle => new ProductArticle
                {
                    ArticleName = usedArticle.Article.ArticleName,
                    ArticleId = usedArticle.ArticleId,
                    AmountOf = usedArticle.ArticleQuantity

                }).ToList()

            }).ToList();
        }

        public async Task<Product> GetProductById(int productId)
        {
            var productViewData = new Product();
            var productRepoData = await _productRepository.GetProductById(productId);

            if (productRepoData == null)
            {
                return null;
            }

            productViewData.ProductId = productRepoData.ProductId;
            productViewData.Price = productRepoData.ProductPrice;
            productViewData.Name = productRepoData.ProductName;
            productViewData.ContainArticles = productRepoData.UsedArticles.Select(article => new ProductArticle
            {
                ArticleId = article.ArticleId,
                ArticleName = article.Article.ArticleName,
                AmountOf = article.ArticleQuantity
            }).ToList();

            return productViewData;
        }

        public int? UpdateProduct(Product product)
        {
            var productRepoData = new Warehouse.DAL.Models.Product
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                ProductPrice = product.Price,
                UsedArticles = product.ContainArticles.Select(article => new DAL.Models.ProductArticle
                {
                    ArticleId = article.ArticleId,
                    ArticleQuantity = article.AmountOf
                }).ToList()
            };
            return _productRepository.UpdateProduct(productRepoData);
        }
    }
}
