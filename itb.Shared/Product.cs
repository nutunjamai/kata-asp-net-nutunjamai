using System;
using System.Collections.Generic;
using System.Text;

namespace itb.Shared
{
    class Product : IProductRepository
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
