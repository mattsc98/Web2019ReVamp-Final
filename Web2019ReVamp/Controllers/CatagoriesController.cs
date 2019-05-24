using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web2019ReVamp.Models;

namespace Web2019ReVamp.Controllers
{
    public class CatagoriesController : Controller
    {
        private readonly Web2019ReVampContext _context;

       public CatagoriesController(Web2019ReVampContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Catagories> catagoriesList = new List<Catagories>();

            //catagoriesList = (from Catagories in _context.Catagoies select Catagories).ToList();

            ViewBag.catagoriesLists = catagoriesList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Catagories catagories)
        {
            if (ModelState.IsValid)
            {
                var msg = catagories.Catagory + " selected";
                //return RedirectToAction("IndexSuccess", new { message = msg });
            }

            // If we got this far, something failed; redisplay form.
            return View(catagories);
        }

    }
}
