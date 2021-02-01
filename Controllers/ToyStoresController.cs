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
    public class ToyStoresController : Controller
    {
        private readonly ToysMVCASPContext _context;

        public ToyStoresController(ToysMVCASPContext context)
        {
            _context = context;
        }

        // GET: ToyStores
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToyStore.ToListAsync());
        }

        // GET: ToyStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toyStore = await _context.ToyStore
                .FirstOrDefaultAsync(m => m.ToyStoreId == id);
            if (toyStore == null)
            {
                return NotFound();
            }

            return View(toyStore);
        }

        // GET: ToyStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToyStores/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToyStoreId,StoreNAme,City,Phone,OpeningTime,ClosingTime")] ToyStore toyStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toyStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toyStore);
        }

        // GET: ToyStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toyStore = await _context.ToyStore.FindAsync(id);
            if (toyStore == null)
            {
                return NotFound();
            }
            return View(toyStore);
        }

        // POST: ToyStores/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToyStoreId,StoreNAme,City,Phone,OpeningTime,ClosingTime")] ToyStore toyStore)
        {
            if (id != toyStore.ToyStoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toyStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToyStoreExists(toyStore.ToyStoreId))
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
            return View(toyStore);
        }

        // GET: ToyStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toyStore = await _context.ToyStore
                .FirstOrDefaultAsync(m => m.ToyStoreId == id);
            if (toyStore == null)
            {
                return NotFound();
            }

            return View(toyStore);
        }

        // POST: ToyStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toyStore = await _context.ToyStore.FindAsync(id);
            _context.ToyStore.Remove(toyStore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToyStoreExists(int id)
        {
            return _context.ToyStore.Any(e => e.ToyStoreId == id);
        }
    }
}
