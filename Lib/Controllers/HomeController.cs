using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lib.Models;
using Microsoft.EntityFrameworkCore;

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
            return View(db.Libraries);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Library library)
        {
            db.Books.Add(library.Book);
            db.Authors.Add(library.Author);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
