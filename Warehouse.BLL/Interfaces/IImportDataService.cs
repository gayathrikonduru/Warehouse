using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common.Models;

namespace Warehouse.BLL.Interfaces
{
    public interface IImportDataService
    {
        void ImportProductsData(List<Product> productsList);

        void ImportArticlesData(List<Article> articlesList);
    }
}
