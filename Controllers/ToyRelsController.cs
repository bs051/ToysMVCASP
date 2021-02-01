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
    public class ToyRelsController : Controller
    {
        private readonly ToysMVCASPContext _context;

        public ToyRelsController(ToysMVCASPContext context)
        {
            _context = context;
        }

        // GET: ToyRels
        public async Task<IActionResult> Index()
        {
            var toysMVCASPContext = _context.ToyRel.Include(t => t.ToyObj).Include(t => t.ToyStoreObj);
            return View(await toysMVCASPContext.ToListAsync());
        }

        // GET: ToyRels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toyRel = await _context.ToyRel
                .Include(t => t.ToyObj)
                .Include(t => t.ToyStoreObj)
                .FirstOrDefaultAsync(m => m.ToyRelId == id);
            if (toyRel == null)
            {
                return NotFound();
            }

            return View(toyRel);
        }

        // GET: ToyRels/Create
        public IActionResult Create()
        {
            ViewData["ToyId"] = new SelectList(_context.Toy, "ToyId", "ToyId");
            ViewData["ToyStoreId"] = new SelectList(_context.ToyStore, "ToyStoreId", "ToyStoreId");
            return View();
        }

        // POST: ToyRels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToyRelId,InStock,AvailableQuantity,ToyId,ToyStoreId")] ToyRel toyRel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toyRel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToyId"] = new SelectList(_context.Toy, "ToyId", "ToyId", toyRel.ToyId);
            ViewData["ToyStoreId"] = new SelectList(_context.ToyStore, "ToyStoreId", "ToyStoreId", toyRel.ToyStoreId);
            return View(toyRel);
        }

        // GET: ToyRels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toyRel = await _context.ToyRel.FindAsync(id);
            if (toyRel == null)
            {
                return NotFound();
            }
            ViewData["ToyId"] = new SelectList(_context.Toy, "ToyId", "ToyId", toyRel.ToyId);
            ViewData["ToyStoreId"] = new SelectList(_context.ToyStore, "ToyStoreId", "ToyStoreId", toyRel.ToyStoreId);
            return View(toyRel);
        }

        // POST: ToyRels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToyRelId,InStock,AvailableQuantity,ToyId,ToyStoreId")] ToyRel toyRel)
        {
            if (id != toyRel.ToyRelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toyRel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToyRelExists(toyRel.ToyRelId))
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
            ViewData["ToyId"] = new SelectList(_context.Toy, "ToyId", "ToyId", toyRel.ToyId);
            ViewData["ToyStoreId"] = new SelectList(_context.ToyStore, "ToyStoreId", "ToyStoreId", toyRel.ToyStoreId);
            return View(toyRel);
        }

        // GET: ToyRels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toyRel = await _context.ToyRel
                .Include(t => t.ToyObj)
                .Include(t => t.ToyStoreObj)
                .FirstOrDefaultAsync(m => m.ToyRelId == id);
            if (toyRel == null)
            {
                return NotFound();
            }

            return View(toyRel);
        }

        // POST: ToyRels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toyRel = await _context.ToyRel.FindAsync(id);
            _context.ToyRel.Remove(toyRel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToyRelExists(int id)
        {
            return _context.ToyRel.Any(e => e.ToyRelId == id);
        }
    }
}
