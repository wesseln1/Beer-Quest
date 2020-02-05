using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beer_Quest.Data;
using Beer_Quest.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Beer_Quest.Models.ViewModels;

namespace Beer_Quest.Controllers
{
    public class BreweriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BreweriesController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Breweries
        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString != null)
            {
                var model = await _context.Brewery.Include(b => b.Drinks).Where(b => b.City.Contains(searchString)).Select(b => new BreweryCheerCountViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Address = b.Address,
                    Phone = b.Phone,
                    ZipCode = b.ZipCode,
                    City = b.City,
                    ImagePath = b.ImagePath,
                    CheersCount = b.Cheers.Count(),
                    CommentCount = b.Comments.Count()
                }).ToListAsync();
                return View(model);
            }
            else
            {
                var model = await _context.Brewery.Include(b => b.Drinks).Select(b => new BreweryCheerCountViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Address = b.Address,
                    Phone = b.Phone,
                    ZipCode = b.ZipCode,
                    City = b.City,
                    ImagePath = b.ImagePath,
                    CheersCount = b.Cheers.Count()
                }).ToListAsync();
                return View(model);
            }
        }

        // GET: Breweries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brewery = await _context.Brewery
                .Include(b => b.Drinks)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brewery == null)
            {
                return NotFound();
            }

            return View(brewery);
        }

        // GET: Breweries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Breweries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,City,ZipCode,Phone,CheersCount,UserId,File,ImagePath")] Brewery brewery, IFormFile file)
        {
            var user = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                brewery.UserId = user.Id;
            }

            if (brewery.File != null && brewery.File.Length > 0)
            {
                var fileName = Path.GetFileName(brewery.File.FileName); //getting path of actual file name
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName); //creating path combining file name w/ www.root\\images directory
                using (var fileSteam = new FileStream(filePath, FileMode.Create)) //using filestream to get the actual path 
                {
                    await brewery.File.CopyToAsync(fileSteam);
                }
                brewery.ImagePath = fileName;
            }
            _context.Add(brewery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheer([Bind("Id,UserId,BreweryId")] Cheer cheer)
        {
            if (ModelState.IsValid)
            {
    
                _context.Add(cheer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Breweries");
            }
            return View();
        }

        // GET: Breweries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brewery = await _context.Brewery.FindAsync(id);
            if (brewery == null)
            {
                return NotFound();
            }
            return View(brewery);
        }

        // POST: Breweries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,ZipCode,Phone,CheersCount,UserId")] Brewery brewery)
        {
            if (id != brewery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brewery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreweryExists(brewery.Id))
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
            return View(brewery);
        }

        // GET: Breweries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brewery = await _context.Brewery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brewery == null)
            {
                return NotFound();
            }

            return View(brewery);
        }

        // POST: Breweries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brewery = await _context.Brewery.FindAsync(id);
            _context.Brewery.Remove(brewery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreweryExists(int id)
        {
            return _context.Brewery.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
