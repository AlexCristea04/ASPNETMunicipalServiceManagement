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
    public class WaterSupplyController : Controller
    {
        private readonly MunicipalDbContext _context;

        public WaterSupplyController(MunicipalDbContext context)
        {
            _context = context;
        }

        // GET: WaterSupply
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterSupplies.ToListAsync());
        }

        // GET: WaterSupply/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterSupply = await _context.WaterSupplies
                .FirstOrDefaultAsync(m => m.WaterSupplyId == id);
            if (waterSupply == null)
            {
                return NotFound();
            }

            return View(waterSupply);
        }

        // GET: WaterSupply/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WaterSupply/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WaterSupplyId,Location,DailyConsumption,WaterQualityRating")] WaterSupply waterSupply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waterSupply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waterSupply);
        }

        // GET: WaterSupply/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterSupply = await _context.WaterSupplies.FindAsync(id);
            if (waterSupply == null)
            {
                return NotFound();
            }
            return View(waterSupply);
        }

        // POST: WaterSupply/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WaterSupplyId,Location,DailyConsumption,WaterQualityRating")] WaterSupply waterSupply)
        {
            if (id != waterSupply.WaterSupplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waterSupply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaterSupplyExists(waterSupply.WaterSupplyId))
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
            return View(waterSupply);
        }

        // GET: WaterSupply/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waterSupply = await _context.WaterSupplies
                .FirstOrDefaultAsync(m => m.WaterSupplyId == id);
            if (waterSupply == null)
            {
                return NotFound();
            }

            return View(waterSupply);
        }

        // POST: WaterSupply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waterSupply = await _context.WaterSupplies.FindAsync(id);
            if (waterSupply != null)
            {
                _context.WaterSupplies.Remove(waterSupply);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaterSupplyExists(int id)
        {
            return _context.WaterSupplies.Any(e => e.WaterSupplyId == id);
        }
    }
}
