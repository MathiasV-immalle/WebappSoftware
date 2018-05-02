using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webappSOFT.Models;

namespace webappSOFT.Controllers
{
    public class SoundsController : Controller
    {
        private readonly webappSOFTContext _context;

        public SoundsController(webappSOFTContext context)
        {
            _context = context;
        }

        // GET: Sounds
        public async Task<IActionResult> Index(string titleSearchString, string artistSearchString, string soundGenre)
        {
            IQueryable<string> genreQuery = from m in _context.Sound
                                            orderby m.Genre
                                            select m.Genre;

            var sounds = from m in _context.Sound
                        select m;

            if (!String.IsNullOrEmpty(titleSearchString))
            {
                sounds = sounds.Where(s => s.Title.Contains(titleSearchString));
            }

            if (!String.IsNullOrEmpty(artistSearchString))
            {
                sounds = sounds.Where(s => s.Artist1.Contains(artistSearchString) || s.Artist2.Contains(artistSearchString) || s.Artist3.Contains(artistSearchString));
            }

            if (!String.IsNullOrEmpty(soundGenre))
            {
                sounds = sounds.Where(s => s.Genre.Contains(soundGenre));
            }

            var soundGenreVM = new SoundGenre();
            soundGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            soundGenreVM.sounds = await sounds.ToListAsync();

            return View(soundGenreVM);
        }

        // GET: Sounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sound = await _context.Sound
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sound == null)
            {
                return NotFound();
            }

            return View(sound);
        }

        // GET: Sounds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Artist1,Artist2,Artist3,Remix,ReleaseDate,Genre")] Sound sound)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sound);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sound);
        }

        // GET: Sounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sound = await _context.Sound.SingleOrDefaultAsync(m => m.ID == id);
            if (sound == null)
            {
                return NotFound();
            }
            return View(sound);
        }

        // POST: Sounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Artist1,Artist2,Artist3,Remix,ReleaseDate,Genre")] Sound sound)
        {
            if (id != sound.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sound);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoundExists(sound.ID))
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
            return View(sound);
        }

        // GET: Sounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sound = await _context.Sound
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sound == null)
            {
                return NotFound();
            }

            return View(sound);
        }

        // POST: Sounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sound = await _context.Sound.SingleOrDefaultAsync(m => m.ID == id);
            _context.Sound.Remove(sound);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoundExists(int id)
        {
            return _context.Sound.Any(e => e.ID == id);
        }
    }
}
