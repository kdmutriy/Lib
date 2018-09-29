using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lib.Models;
using Microsoft.EntityFrameworkCore;
using Lib.ViewModels;

namespace Lib.Controllers
{
    public class HomeController : Controller
    {
        private LibContext db;
        public HomeController(LibContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {

            //var courses = db.Books.Include(c => c.Libraries).ThenInclude(sc => sc.Author).ToList();
            //var courses = db.Books.Include(c => c.Libraries).ThenInclude(sc => sc.Author).FirstOrDefault();
            var courses = db.Libraries.Include(a => a.Author).Include(b => b.Book).ToList();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(Library library)
        {
            db.Books.Add(library.Book);
            db.Authors.Add(library.Author);
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
