using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web2019ReVamp.Data;
using Web2019ReVamp.Models;

namespace Web2019ReVamp.Controllers
{
    public class InvestigationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvestigationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Investigations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Investigations.Include(i => i.ApplicationUser).Include(i => i.Reports);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Investigations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigations = await _context.Investigations
                .Include(i => i.ApplicationUser)
                .Include(i => i.Reports)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investigations == null)
            {
                return NotFound();
            }

            return View(investigations);
        }

        // GET: Investigations/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Id");
            return View();
        }

        // POST: Investigations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ReportId,InvEntry")] Investigations investigations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investigations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", investigations.UserId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Id", investigations.ReportId);
            return View(investigations);
        }

        // GET: Investigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigations = await _context.Investigations.FindAsync(id);
            if (investigations == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", investigations.UserId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Id", investigations.ReportId);
            return View(investigations);
        }

        // POST: Investigations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ReportId,InvEntry")] Investigations investigations)
        {
            if (id != investigations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investigations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestigationsExists(investigations.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", investigations.UserId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Id", investigations.ReportId);
            return View(investigations);
        }

        // GET: Investigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigations = await _context.Investigations
                .Include(i => i.ApplicationUser)
                .Include(i => i.Reports)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (investigations == null)
            {
                return NotFound();
            }

            return View(investigations);
        }

        // POST: Investigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investigations = await _context.Investigations.FindAsync(id);
            _context.Investigations.Remove(investigations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestigationsExists(int id)
        {
            return _context.Investigations.Any(e => e.Id == id);
        }
    }
}
