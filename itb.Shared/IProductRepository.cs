﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace itb.Shared
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>>GetProducts();
        Task<Product> GetProduct(int id);
        int DeleteProduct(int id);
        int UpdateProduct(Product prod);
        int AddProduct(Product prod);
    }
}
