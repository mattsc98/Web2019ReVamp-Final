using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web2019ReVamp.Models;
using System.IO;
using System.Security.Claims;
using Web2019ReVamp.Data;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

//testing commit aaa
namespace Web2019ReVamp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly Web2019ReVampContext _context;
        private readonly ApplicationDbContext _contextDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportsController(Web2019ReVampContext context, ApplicationDbContext contextDb, UserManager<ApplicationUser> userManager)
        {
            _contextDbContext = contextDb;
            _context = context;
            _userManager = userManager;
        }

        // GET: Reports
        public async Task<IActionResult> Index(string sortOrder)
        {
            var reports = from s in _context.Reports
                          select s;
            var test = _contextDbContext.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            switch (sortOrder)
            {
                case "Upvotes":
                    reports = reports.OrderByDescending(s => s.Upvotes);
                    break;
                case "ReportDate":
                    reports = reports.OrderByDescending(s => s.RepDate);
                    break;
                case "IncidentDate":
                    reports = reports.OrderByDescending(s => s.HazardDateTime);
                    break;
                case "Personal":
                    if (test == null)
                    {
                        reports = reports.OrderByDescending(s => s.RepDate);

                        break;
                    }
                    else {
                        reports = reports.Where(s => (s.UserId == test.Id)).OrderByDescending(s => s.RepDate);
                        break;
                    }
                    
                    reports = reports.Where(s => (s.UserId == test.Id)).OrderByDescending(s => s.RepDate);
                    break;
                default:
                    reports = reports.OrderByDescending(s => s.RepDate);
                    break;
            }


            return View(await reports.AsNoTracking().ToListAsync());
        }



        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reports item, IFormFile Photo)
        {
            var test = _contextDbContext.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));
                

            if (ModelState.IsValid)
            {
                if (Photo != null && Photo.Length > 0)
                {
                    var fileName = Path.GetFileName(Photo.FileName);
                    var filePath = Path.Combine("wwwroot\\images\\items", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await Photo.CopyToAsync(fileSteam);
                    }
                    var fileNameStorage = Path.Combine("/Images/items/", fileName);
                    item.Photo = fileNameStorage;
                    item.PhotoName = fileName;

                }
                else
                {
                    item.PhotoName = "default";
                    var photo = Path.Combine("/Images/items/", "default.jpg");
                    item.Photo = photo;

                    //item.Photo = "~/Images/items/default.jpg";
                }

                item.RepDate = DateTime.Now;
                item.Status = "open";
                item.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                item.userEmail = test.Email;
                var cur = test.totalReports + 1;
                test.totalReports = cur;

                _contextDbContext.Update(test);
                await _contextDbContext.SaveChangesAsync();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Nemesys Reporting System", "cachiamatthew1998@gmail.com"));
                message.To.Add(new MailboxAddress(item.UserId, item.userEmail));
                message.Subject = "New Report";

                message.Body = new TextPart("plain")
                {
                    Text = @"Hey " + test.FirstName + @", Your latest report is currently set to open and will be investigated by out team"
                };

            
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports.FindAsync(id);
            if (reports == null)
            {
                return NotFound();
            }
            return View(reports);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reports reports, IFormFile Photo)
        {
            if (id != reports.Id)
            {
                return NotFound();
            }
            var test = _contextDbContext.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (ModelState.IsValid)
            {
                if (test.Id.Equals(null) || !test.Id.Equals(reports.UserId) || User.IsInRole("Investigator"))
                {
                    return NotFound();

                }
                if (Photo != null && Photo.Length > 0)
                {
                    var fileName = Path.GetFileName(Photo.FileName);
                    var filePath = Path.Combine("wwwroot\\images\\items", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await Photo.CopyToAsync(fileSteam);
                    }
                    var fileNameStorage = Path.Combine("/Images/items/", fileName);
                    reports.Photo = fileNameStorage;
                    reports.PhotoName = fileName;

                }
                else
                {
                    reports.PhotoName = "default";
                    var photo = Path.Combine("/Images/items/", "default.jpg");
                    reports.Photo = photo;

                    //item.Photo = "~/Images/items/default.jpg";
                }

                try
                {
                    reports.RepDate = DateTime.Now;
                    reports.Status = "open";
                    reports.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                    reports.userEmail = test.Email;
                    _context.Update(reports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsExists(reports.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reports);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reports = await _context.Reports.FindAsync(id);
            var test = _contextDbContext.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (test.Id.Equals(null) || !test.Id.Equals(reports.UserId) || User.IsInRole("Investigator"))
            {
                return NotFound();

            }
            _context.Reports.Remove(reports);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportsExists(int id)
        {
            return _context.Reports.Any(e => e.Id == id);
        }

        //upvotes
        [HttpGet]
        [Authorize]
        public async Task<int> IncrementUpvotes(int reportId)
        {

            //save person id that is doing the upvote and report id 

            //if user already upvoted do nothing

            if (_context.Upvotes.Where(u => u.UserId == _userManager.GetUserId(User) && u.ReportId == reportId).Any())
            {
                return 0;
            }
            //else increment upvotes
            else
            {
                _context.Upvotes.Add(new Upvotes
                {
                    ReportId = reportId,
                    UserId = _userManager.GetUserId(User)
                });
                var report = _context.Reports.Where(x => x.Id == reportId).Single();
                report.Upvotes++;
                await _context.SaveChangesAsync();
                return report.Upvotes;
            }
            
        }
    }
}
