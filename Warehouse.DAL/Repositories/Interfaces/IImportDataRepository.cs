using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL.Models;

namespace Warehouse.DAL.Repositories.Interfaces
{
    public interface IImportDataRepository
    {
        void ImportProductsData(List<Product> products);
        void ImportArticlesData(List<Article> products);

    }
}
