using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common.Models;

namespace Warehouse.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProducts();

        Task<Product> GetProductById(int productId);

        int AddNewProduct(Product product);

        int? UpdateProduct(Product product);

        int? DeleteProduct(int productId);
    }
}
