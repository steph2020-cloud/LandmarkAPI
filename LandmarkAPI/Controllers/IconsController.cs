using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LandmarkAPI.Data;
using LandmarksAPI.Models;

namespace LandmarkAPI.Controllers
{
    public class IconsController : Controller
    {
        private readonly LandmarkDbContext _context;

        public IconsController(LandmarkDbContext context)
        {
            _context = context;
        }

        // GET: Icons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Icons.ToListAsync());
        }

        // GET: Icons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icon = await _context.Icons
                .FirstOrDefaultAsync(m => m.ID == id);
            if (icon == null)
            {
                return NotFound();
            }

            return View(icon);
        }

        // GET: Icons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Icons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Prefix,Suffix")] Icon icon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(icon);
        }

        // GET: Icons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icon = await _context.Icons.FindAsync(id);
            if (icon == null)
            {
                return NotFound();
            }
            return View(icon);
        }

        // POST: Icons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Prefix,Suffix")] Icon icon)
        {
            if (id != icon.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IconExists(icon.ID))
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
            return View(icon);
        }
        #region not using image method since foursquares has permissions on images returned by API 
        //public ActionResult ImageDetails(int id)
        //{
        //    byte[] locationImage =GetStoredImage(id);
        //    if (locationImage != null)
        //    {
        //        return File(locationImage, "image/jpg");
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //public byte[] GetStoredImage(int Id)
        //{
        //    var q = from temp in _context.Icons where temp.ID == Id select temp.Prefix + temp.Suffix;
        //    byte[] locationImage = q.First();
        //    return locationImage;
        //}
        #endregion

        // GET: Icons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icon = await _context.Icons
                .FirstOrDefaultAsync(m => m.ID == id);
            if (icon == null)
            {
                return NotFound();
            }

            return View(icon);
        }

        // POST: Icons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var icon = await _context.Icons.FindAsync(id);
            _context.Icons.Remove(icon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IconExists(int id)
        {
            return _context.Icons.Any(e => e.ID == id);
        }
    }
}
