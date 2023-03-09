using Microsoft.AspNetCore.Mvc;
using onlineBookstoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstoreApp.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IOnlineBookstoreRepository repo { get; set; }

        public CategoriesViewComponent (IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Selected = RouteData?.Values["category"];
            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(categories);
        }
    }
}
