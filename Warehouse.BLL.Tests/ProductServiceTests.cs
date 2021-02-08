using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Warehouse.DAL;
using Warehouse.Common.Models;
using Warehouse.DAL.Repositories.Implemenations;
using Warehouse.DAL.Repositories.Interfaces;
using Warehouse.BLL.Implementations;

namespace Warehouse.BLL.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<WarehouseDbContext> _warehouseDbContextMock;
        private Mock<IProductRepository> _productRepositoryMock;
        private ProductService _productService;

        [SetUp]
        public void Setup()
        {

            _warehouseDbContextMock = new Mock<WarehouseDbContext>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }       

        [Test]
        public void Test_UpdateProduct()
        {
            var product = new Product { ProductId = 2, Name = "Dining chair", Price = 250 };            

            _productService.UpdateProduct(product);

        }

        [Test]
        public void Test_AddNewProduct()
        {
            var product = new Product { Name = "Spoon", Price = 40 };

            _productService.AddNewProduct(product);

        }

        [Test]
        public void Test_DeleteProduct()
        {
            _productService.DeleteProduct(1);

        }
    }
}
