using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web2019ReVamp.Models;

namespace Web2019ReVamp.Controllers
{
    public class UpvotesController : Controller
    {
        private readonly Web2019ReVampContext _context;

        public UpvotesController(Web2019ReVampContext context)
        {
            _context = context;
        }

        // GET: Upvotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Upvotes.ToListAsync());
        }

        // GET: Upvotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upvotes = await _context.Upvotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upvotes == null)
            {
                return NotFound();
            }

            return View(upvotes);
        }

        // GET: Upvotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Upvotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,InvId,UpvotesCounter")] Upvotes upvotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upvotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(upvotes);
        }

        // GET: Upvotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upvotes = await _context.Upvotes.FindAsync(id);
            if (upvotes == null)
            {
                return NotFound();
            }
            return View(upvotes);
        }

        // POST: Upvotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,InvId,UpvotesCounter")] Upvotes upvotes)
        {
            if (id != upvotes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upvotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpvotesExists(upvotes.Id))
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
            return View(upvotes);
        }

        // GET: Upvotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upvotes = await _context.Upvotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upvotes == null)
            {
                return NotFound();
            }

            return View(upvotes);
        }

        // POST: Upvotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upvotes = await _context.Upvotes.FindAsync(id);
            _context.Upvotes.Remove(upvotes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpvotesExists(int id)
        {
            return _context.Upvotes.Any(e => e.Id == id);
        }
    }
}
