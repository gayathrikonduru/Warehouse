﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Common.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }
    }
}
