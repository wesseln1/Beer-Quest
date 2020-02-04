using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beer_Quest.Data;
using Beer_Quest.Models;
using Microsoft.AspNetCore.Identity;

namespace Beer_Quest.Controllers
{
    public class CheersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Cheers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cheer.ToListAsync());
        }

        // GET: Cheers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheer = await _context.Cheer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheer == null)
            {
                return NotFound();
            }

            return View(cheer);
        }

        // POST: Cheers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int breweryId)
        {
            var user = await GetCurrentUserAsync();
            var cheers = await _context.Cheer.Where(c => c.UserId == user.Id && c.BreweryId == breweryId).FirstOrDefaultAsync();
            var cheer = new Cheer();

            if (cheers != null)
            {
                return RedirectToAction("Index", "Breweries");
            }
            else if(ModelState.IsValid && cheers == null)
            {
                cheer.BreweryId = breweryId;
                cheer.UserId = user.Id;
                _context.Add(cheer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Breweries");
            }
            return View();
        }

        // GET: Cheers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheer = await _context.Cheer.FindAsync(id);
            if (cheer == null)
            {
                return NotFound();
            }
            return View(cheer);
        }

        // POST: Cheers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BreweryId")] Cheer cheer)
        {
            if (id != cheer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheerExists(cheer.Id))
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
            return View(cheer);
        }

        // GET: Cheers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheer = await _context.Cheer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheer == null)
            {
                return NotFound();
            }

            return View(cheer);
        }

        // POST: Cheers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cheer = await _context.Cheer.FindAsync(id);
            _context.Cheer.Remove(cheer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheerExists(int id)
        {
            return _context.Cheer.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
