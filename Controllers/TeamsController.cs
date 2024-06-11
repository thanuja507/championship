using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using F1Championship.Data;
using F1Championship.Models;

namespace F1Championship.Controllers
{
    public class TeamsController : Controller
    {
        private readonly F1ChampionshipContext _context;

        public TeamsController(F1ChampionshipContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Teams> teamsList = _context.Teams.ToList();
            return View(teamsList);
        }


        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var teams = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teams == null)
            {
                return NotFound();
            }

            return View(teams);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName,Headquarters,TeamPrincipal,Chassis,Engine,Drivers")] Teams teams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teams);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teams);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var teams = await _context.Teams.FindAsync(id);
            if (teams == null)
            {
                return NotFound();
            }
            return View(teams);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,Headquarters,TeamPrincipal,Chassis,Engine,Drivers")] Teams teams)
        {
            if (id != teams.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teams);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamsExists(teams.Id))
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
            return View(teams);
        }

        //// GET: Teams/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Teams == null)
        //    {
        //        return NotFound();
        //    }

        //    var teams = await _context.Teams
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (teams == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(teams);
        //}

        // GET: Teams/Delete/5
        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);

            if (team == null)
            {
                return NotFound();
            }

            // Check if there are any drivers associated with this team
            var hasDrivers = await _context.Drivers.AnyAsync(d => d.TeamId == id);
            // Check if there are any leagues associated with this team
            var hasLeagues = await _context.Leagues.AnyAsync(l => l.TeamId == id);

            if (hasDrivers || hasLeagues)
            {
                // If there are associated drivers or leagues, set an error message
                ViewData["ErrorMessage"] = "This team cannot be deleted as it has drivers or leagues associated with it.";
            }

            return View(team);
        }



        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teams == null)
            {
                return Problem("Entity set 'F1ChampionshipContext.Teams'  is null.");
            }
            var teams = await _context.Teams.FindAsync(id);
            if (teams != null)
            {
                _context.Teams.Remove(teams);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamsExists(int id)
        {
          return (_context.Teams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
