using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.DAL.Models
{
    public class ProductArticle
    {
        [Key]
        public Guid Id { get; set; }

        public virtual Product Product { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public int ArticleQuantity { get; set; }
    }
}
