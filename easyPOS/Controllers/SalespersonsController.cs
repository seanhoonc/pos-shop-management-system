using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using easyPOS.Models;

namespace easyPOS.Controllers
{
    public class SalespersonsController : Controller
    {
        private readonly easyPOSDbContext _context;

        public SalespersonsController(easyPOSDbContext context)
        {
            _context = context;
        }

        // GET: Salespersons
        public async Task<IActionResult> Index()
        {
              return _context.Salespeoples != null ? 
                          View(await _context.Salespeoples.ToListAsync()) :
                          Problem("Entity set 'easyPOSDbContext.Salespeoples'  is null.");
        }

        // GET: Salespersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salespeoples == null)
            {
                return NotFound();
            }

            var salesperson = await _context.Salespeoples
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (salesperson == null)
            {
                return NotFound();
            }

            return View(salesperson);
        }

        // GET: Salespersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salespersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,Role,Name,Email,Contact")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesperson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesperson);
        }

        // GET: Salespersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salespeoples == null)
            {
                return NotFound();
            }

            var salesperson = await _context.Salespeoples.FindAsync(id);
            if (salesperson == null)
            {
                return NotFound();
            }
            return View(salesperson);
        }

        // POST: Salespersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,Role,Name,Email,Contact")] Salesperson salesperson)
        {
            if (id != salesperson.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesperson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalespersonExists(salesperson.UserId))
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
            return View(salesperson);
        }

        // GET: Salespersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salespeoples == null)
            {
                return NotFound();
            }

            var salesperson = await _context.Salespeoples
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (salesperson == null)
            {
                return NotFound();
            }

            return View(salesperson);
        }

        // POST: Salespersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salespeoples == null)
            {
                return Problem("Entity set 'easyPOSDbContext.Salespeoples'  is null.");
            }
            var salesperson = await _context.Salespeoples.FindAsync(id);
            if (salesperson != null)
            {
                _context.Salespeoples.Remove(salesperson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalespersonExists(int id)
        {
          return (_context.Salespeoples?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
