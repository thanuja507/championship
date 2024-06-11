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
    public class LeaguesController : Controller
    {
        private readonly F1ChampionshipContext _context;

        public LeaguesController(F1ChampionshipContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Leagues> leaguesList = _context.Leagues.ToList();
            return View(leaguesList);
        }

        // GET: Leagues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Leagues == null)
            {
                return NotFound();
            }

            var leagues = await _context.Leagues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leagues == null)
            {
                return NotFound();
            }

            return View(leagues);
        }

        // GET: Leagues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamId,Team,League")] Leagues leagues)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(leagues);
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
                        ModelState.AddModelError(string.Empty, "An error occurred while saving the league. Please try again later.");
                    }
                }
            }
            return View(leagues);
        }


        // GET: Leagues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Leagues == null)
            {
                return NotFound();
            }

            var leagues = await _context.Leagues.FindAsync(id);
            if (leagues == null)
            {
                return NotFound();
            }
            return View(leagues);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamId,Team,League")] Leagues leagues)
        {
            if (id != leagues.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leagues);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaguesExists(leagues.Id))
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
            return View(leagues);
        }

        // GET: Leagues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Leagues == null)
            {
                return NotFound();
            }

            var leagues = await _context.Leagues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leagues == null)
            {
                return NotFound();
            }

            return View(leagues);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Leagues == null)
            {
                return Problem("Entity set 'F1ChampionshipContext.Leagues'  is null.");
            }
            var leagues = await _context.Leagues.FindAsync(id);
            if (leagues != null)
            {
                _context.Leagues.Remove(leagues);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaguesExists(int id)
        {
          return (_context.Leagues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
