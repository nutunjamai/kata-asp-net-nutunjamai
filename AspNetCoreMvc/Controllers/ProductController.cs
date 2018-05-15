using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc.Models;
using itb.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _prodRepo;

        public ProductController(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        // GET: Product1
        public async Task<ActionResult> Index()
        {
            var products = await _prodRepo.GetProducts();
            return View(products);
        }

        // GET: Product1/Details/5
        public ActionResult Details(int id)
        {
            var products = _prodRepo.GetProduct(id);
            return View(products);
        }

        // GET: Product1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var name = collection["Name"];
                Product prod = new Product() {Name = name};
                _prodRepo.AddProduct(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product1/Edit/5
        public ActionResult Edit(int id)
        {
           return View();
        }

        // POST: Product1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}