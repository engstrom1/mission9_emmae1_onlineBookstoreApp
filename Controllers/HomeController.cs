using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineBookstoreApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using onlineBookstoreApp.Models.ViewModels;

namespace onlineBookstoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IOnlineBookstoreRepository repo;

        public HomeController (IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 2;
            var x = new IndexViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumEntries = 
                    (category == null 
                    ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == category).Count()),
                    EntriesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
