using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web2019ReVamp.Data;

namespace Web2019ReVamp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task <IActionResult> UsersViewer()
        {
            var usersList = from user in _context.Users select user;
            usersList = usersList.OrderByDescending(user => user.totalReports).Take(5);
            

            return View(await usersList.AsNoTracking().ToListAsync());
        }
    }
}