using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Common.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<ProductArticle> ContainArticles { get; set; }

        //public ProductViewModel(Guid productId, string name, List<ProductArticle> containArticle)
        //{
        //    ProductId = productId;
        //    Name = name;
        //}
    }
}
