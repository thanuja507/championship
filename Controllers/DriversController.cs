using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using F1Championship.Data;
using F1Championship.Models;
using Microsoft.Data.SqlClient;

namespace F1Championship.Controllers
{
    public class DriversController : Controller
    {
        private readonly F1ChampionshipContext _context;

        public DriversController(F1ChampionshipContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Drivers> driversList = _context.Drivers.ToList();
            return View(driversList);
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamId,DriverName,Team,Country")] Drivers drivers)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(drivers);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                    {
                        ModelState.AddModelError(string.Empty, "The selected team does not exist. Please choose a valid team.");
                    }
                    else
                    {
                        // Log or handle other types of exceptions
                        ModelState.AddModelError(string.Empty, "An error occurred while saving the driver. Please try again later.");
                    }
                }
            }
            return View(drivers);
        }


        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers == null)
            {
                return NotFound();
            }
            return View(drivers);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamId,DriverName,Team,Country")] Drivers drivers)
        {
            if (id != drivers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriversExists(drivers.Id))
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
            return View(drivers);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var drivers = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivers == null)
            {
                return NotFound();
            }

            return View(drivers);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drivers == null)
            {
                return Problem("Entity set 'F1ChampionshipContext.Drivers'  is null.");
            }
            var drivers = await _context.Drivers.FindAsync(id);
            if (drivers != null)
            {
                _context.Drivers.Remove(drivers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriversExists(int id)
        {
          return (_context.Drivers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
