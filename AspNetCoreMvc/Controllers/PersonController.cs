using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvc.Models;

namespace AspNetCoreMvc.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            var people = new List<Person>();
            people.Add(new Person { Name = "Cody" });
            people.Add(new Person { Name = "Lisa" });
            people.Add(new Person { Name = "Steven" });
            people.Add(new Person { Name = "Reid" });
            people.Add(new Person { Name = "David" });
            return View(people);

        }

        public IActionResult Edit(int id)
        {
            var person = new Person { Name = "David" };
            return View(person);
        }
        public IActionResult Create()
        {
            var people = new List<Person>();
            people.Add(new Person { Name = "Cody" });
            people.Add(new Person { Name = "Lisa" });
            people.Add(new Person { Name = "Steven" });
            people.Add(new Person { Name = "Reid" });
            people.Add(new Person { Name = "David" });
            return View();
        }
    }
}