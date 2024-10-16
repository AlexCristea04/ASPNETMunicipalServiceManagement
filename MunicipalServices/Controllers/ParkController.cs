using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MunicipalServices.Data;
using MunicipalServices.Models;

namespace MunicipalServices.Controllers
{
    public class ParkController : Controller
    {
        private readonly MunicipalDbContext _context;

        public ParkController(MunicipalDbContext context)
        {
            _context = context;
        }

        // GET: Park
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parks.ToListAsync());
        }

        // GET: Park/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks
                .FirstOrDefaultAsync(m => m.ParkId == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // GET: Park/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Park/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkId,ParkName")] Park park)
        {
            if (ModelState.IsValid)
            {
                _context.Add(park);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(park);
        }

        // GET: Park/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks.FindAsync(id);
            if (park == null)
            {
                return NotFound();
            }
            return View(park);
        }

        // POST: Park/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkId,ParkName")] Park park)
        {
            if (id != park.ParkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(park);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkExists(park.ParkId))
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
            return View(park);
        }

        // GET: Park/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks
                .FirstOrDefaultAsync(m => m.ParkId == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // POST: Park/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var park = await _context.Parks.FindAsync(id);
            if (park != null)
            {
                _context.Parks.Remove(park);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkExists(int id)
        {
            return _context.Parks.Any(e => e.ParkId == id);
        }
    }
}
