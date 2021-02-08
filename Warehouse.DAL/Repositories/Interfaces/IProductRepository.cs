using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL.Models;

namespace Warehouse.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetAllProducts();

        Task<Product> GetProductById(int productId);

        int AddNewProduct(Product product);

        int? UpdateProduct(Product product);

        int? DeleteProduct(int productId);
    }
}
