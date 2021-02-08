using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.DAL.Models
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleId { get; set; }

        public string ArticleName { get; set; }

        public int ArticleStock { get; set; }
    }
}
