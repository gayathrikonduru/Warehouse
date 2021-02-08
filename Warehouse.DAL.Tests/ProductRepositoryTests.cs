using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DAL.Models;
using Warehouse.DAL.Repositories.Implemenations;
using Warehouse.DAL.Repositories.Interfaces;

namespace Warehouse.DAL.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private Mock<WarehouseDbContext> _warehouseDbContextMock;
        private Mock<DbSet<Product>> _productsMock;

        [SetUp]
        public void Setup()
        {
            _warehouseDbContextMock = new Mock<WarehouseDbContext>();
            _productsMock = new Mock<DbSet<Product>>();
            SetupProductsInContext();
        }

        private void SetupProductsInContext()
        {
            var data = new List<Product>
            {
                new Product {ProductId = 1, ProductName = "Dining Table", ProductPrice = 2200 },
                new Product {ProductId = 2, ProductName = "Dining chair", ProductPrice = 230},
            }.AsQueryable();

            _productsMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            _productsMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            _productsMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _productsMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _warehouseDbContextMock.Setup(prodcut => prodcut.Products).Returns(_productsMock.Object);
        }

      
        [Test]
        public void Test_UpdateProduct_When_ProductFound()
        {
            
            var product = new Product { ProductId = 2, ProductName = "Dining chair", ProductPrice = 250 };

            var productRepository = new ProductRepository(_warehouseDbContextMock.Object);
            var response = productRepository.UpdateProduct(product);           

            _warehouseDbContextMock.Verify(context => context.SaveChanges());
           
        }

        [Test]
        public void Test_UpdateProduct_When_NoProductFound()
        {

            var product = new Product { ProductId = 3, ProductName = "Dining chair", ProductPrice = 250 };

            var productRepository = new ProductRepository(_warehouseDbContextMock.Object);
            var response = productRepository.UpdateProduct(product);

            NUnit.Framework.Assert.AreEqual(response, null);
        }

        [Test]
        public void Test_AddNewProduct()
        {
            var product = new Product {ProductName = "Spoon", ProductPrice = 40 };

            var productRepository = new ProductRepository(_warehouseDbContextMock.Object);
            productRepository.AddNewProduct(product);

            _productsMock.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            _warehouseDbContextMock.Verify(context => context.SaveChanges());

        }

        [Test]
        public void Test_DeleteProduct_When_ProductFound()
        {            
            var productRepository = new ProductRepository(_warehouseDbContextMock.Object);
            productRepository.DeleteProduct(1);

            _warehouseDbContextMock.Verify(context => context.SaveChanges());

        }

        [Test]
        public void Test_DeleteProduct_When_ProductNotFound()
        {
            var productId = 4;
            var productRepository = new ProductRepository(_warehouseDbContextMock.Object);
            var response = productRepository.DeleteProduct(productId);

            NUnit.Framework.Assert.AreEqual(response, null);            
        }
    }
}
