using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToysMVCASP.Data;
using ToysMVCASP.Models;

namespace ToysMVCASP.Controllers
{
    public class ToysController : Controller
    {
        private readonly ToysMVCASPContext _context;

        public ToysController(ToysMVCASPContext context)
        {
            _context = context;
        }

        // GET: Toys
        public async Task<IActionResult> Index()
        {
            var toysMVCASPContext = _context.Toy.Include(t => t.CategoryObj);
            return View(await toysMVCASPContext.ToListAsync());
        }

        // GET: Toys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toy
                .Include(t => t.CategoryObj)
                .FirstOrDefaultAsync(m => m.ToyId == id);
            if (toy == null)
            {
                return NotFound();
            }

            return View(toy);
        }

        // GET: Toys/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Toys/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToyId,ToyName,Price,AgeGroup,ToyRating,CategoryID")] Toy toy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryId", "CategoryId", toy.CategoryID);
            return View(toy);
        }

        // GET: Toys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toy.FindAsync(id);
            if (toy == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryId", "CategoryId", toy.CategoryID);
            return View(toy);
        }

        // POST: Toys/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToyId,ToyName,Price,AgeGroup,ToyRating,CategoryID")] Toy toy)
        {
            if (id != toy.ToyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToyExists(toy.ToyId))
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
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryId", "CategoryId", toy.CategoryID);
            return View(toy);
        }

        // GET: Toys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toy = await _context.Toy
                .Include(t => t.CategoryObj)
                .FirstOrDefaultAsync(m => m.ToyId == id);
            if (toy == null)
            {
                return NotFound();
            }

            return View(toy);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toy = await _context.Toy.FindAsync(id);
            _context.Toy.Remove(toy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToyExists(int id)
        {
            return _context.Toy.Any(e => e.ToyId == id);
        }
    }
}
