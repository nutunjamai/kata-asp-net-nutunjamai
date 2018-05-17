using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itb.Repositories;
using itb.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    [Produces("application/json")]
    [Route("api/Api")]
    public class ApiController : Controller
    {
        private readonly IProductRepository _prodRepo;

        public ApiController(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        // GET: api/Api
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _prodRepo.GetProducts();
        }

        // GET: api/Api/5
        [HttpGet("{id}", Name = "Get")]
            Task<Product> Get(int id)
        {
            return _prodRepo.GetProduct(id);
        }
        
        // POST: api/Api
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var prod = new Product() { Name = value };
            _prodRepo.AddProduct(prod);
        }
        
        // PUT: api/Api/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            var prod = new Product() { Name = value, Id = id};
            _prodRepo.UpdateProduct(prod);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _prodRepo.DeleteProduct(id);
        }
    }
}
