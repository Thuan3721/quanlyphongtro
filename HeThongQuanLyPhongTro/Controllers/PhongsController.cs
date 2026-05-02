using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeThongQuanLyPhongTro.Models;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class PhongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Phongs.Include(p => p.MaCoSoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Phongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.MaCoSoNavigation)
                .FirstOrDefaultAsync(m => m.MaPhong == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // GET: Phongs/Create
        public IActionResult Create()
        {
            ViewData["MaCoSo"] = new SelectList(_context.CoSos, "MaCoSo", "MaCoSo");
            return View();
        }

        // POST: Phongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhong,MaCoSo,TenPhong,GiaPhong,DienTich,TrangThai")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCoSo"] = new SelectList(_context.CoSos, "MaCoSo", "MaCoSo", phong.MaCoSo);
            return View(phong);
        }

        // GET: Phongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewData["MaCoSo"] = new SelectList(_context.CoSos, "MaCoSo", "MaCoSo", phong.MaCoSo);
            return View(phong);
        }

        // POST: Phongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhong,MaCoSo,TenPhong,GiaPhong,DienTich,TrangThai")] Phong phong)
        {
            if (id != phong.MaPhong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.MaPhong))
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
            ViewData["MaCoSo"] = new SelectList(_context.CoSos, "MaCoSo", "MaCoSo", phong.MaCoSo);
            return View(phong);
        }

        // GET: Phongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.MaCoSoNavigation)
                .FirstOrDefaultAsync(m => m.MaPhong == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // POST: Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            if (phong != null)
            {
                _context.Phongs.Remove(phong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(int id)
        {
            return _context.Phongs.Any(e => e.MaPhong == id);
        }
    }
}
