using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme08_Task01
{
    public enum ProductCategory
    {
        Food,
        Technics
    }

    public class Product
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public string? ImagePath { get; set; }
    }
}
