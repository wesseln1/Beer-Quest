using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beer_Quest.Data;
using Beer_Quest.Models;

namespace Beer_Quest.Controllers
{
    public class DrinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Drinks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Drink.Include(d => d.Brewery).Include(d => d.DrinkType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Drinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .Include(d => d.Brewery)
                .Include(d => d.DrinkType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // GET: Drinks/Create
        public IActionResult Create(int breweryId)
        {
            ViewBag.breweryId = breweryId;
            ViewData["DrinkTypeId"] = new SelectList(_context.DrinkType, "Id", "Name");
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AlcoholPercent,DrinkTypeId,BreweryId,HouseFav")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drink);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Breweries", new { id = drink.BreweryId});
            }
            ViewData["BreweryId"] = new SelectList(_context.Brewery, "Id", "Id", drink.BreweryId);
            ViewData["DrinkTypeId"] = new SelectList(_context.DrinkType, "Id", "Id", drink.DrinkTypeId);
            return View(drink);
        }

        // GET: Drinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            ViewData["BreweryId"] = new SelectList(_context.Brewery, "Id", "Id", drink.BreweryId);
            ViewData["DrinkTypeId"] = new SelectList(_context.DrinkType, "Id", "Id", drink.DrinkTypeId);
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AlcoholPercent,DrinkTypeId,BreweryId,HouseFav")] Drink drink)
        {
            if (id != drink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkExists(drink.Id))
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
            ViewData["BreweryId"] = new SelectList(_context.Brewery, "Id", "Id", drink.BreweryId);
            ViewData["DrinkTypeId"] = new SelectList(_context.DrinkType, "Id", "Id", drink.DrinkTypeId);
            return View(drink);
        }

        // GET: Drinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .Include(d => d.Brewery)
                .Include(d => d.DrinkType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drink = await _context.Drink.FindAsync(id);
            _context.Drink.Remove(drink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkExists(int id)
        {
            return _context.Drink.Any(e => e.Id == id);
        }
    }
}
