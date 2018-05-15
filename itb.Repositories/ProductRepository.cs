using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using itb.Shared;
using Dapper;

namespace itb.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public int AddProduct(Product prod)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("INSERT INTO product(Name) VALUES (@Name)", prod);
            }
        }

        public int DeleteProduct(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("DELETE FROM product WHERE ProductId = @id", new {id});
            }
        }

        public int UpdateProduct(Product prod)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("UPDATE product SET Name = @name WHERE ProductId = @id", prod);
            }
        }
        public Product GetProduct(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<Product>("SELECT *, ProductId as id FROM product WHERE ProductId = @id").FirstOrDefault();
            }
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.QueryAsync<Product>("SELECT *, ProductId as id FROM product");
            }
        }
    }
}
