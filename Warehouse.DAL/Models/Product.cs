using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.DAL.Models
{
    public class Product
    {
        [Key]        
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductArticle> UsedArticles { get; set; }
    }
}
