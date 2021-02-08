using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Common.Models
{
    public class ProductArticle
    {             
        public string ArticleName { get; set; }
        public int ArticleId { get; set; }       

        public int AmountOf { get; set; }
    }

}
