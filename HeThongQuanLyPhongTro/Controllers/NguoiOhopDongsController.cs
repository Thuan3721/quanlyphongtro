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
    public class NguoiOhopDongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NguoiOhopDongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NguoiOhopDongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NguoiOhopDongs.Include(n => n.MaHopDongNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NguoiOhopDongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiOhopDong = await _context.NguoiOhopDongs
                .Include(n => n.MaHopDongNavigation)
                .FirstOrDefaultAsync(m => m.MaNguoiO == id);
            if (nguoiOhopDong == null)
            {
                return NotFound();
            }

            return View(nguoiOhopDong);
        }

        // GET: NguoiOhopDongs/Create
        public IActionResult Create()
        {
            ViewData["MaHopDong"] = new SelectList(_context.HopDongs, "MaHopDong", "MaHopDong");
            return View();
        }

        // POST: NguoiOhopDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNguoiO,MaHopDong,HoTen,Cccd,SoDienThoai,LaNguoiDaiDien")] NguoiOhopDong nguoiOhopDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiOhopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHopDong"] = new SelectList(_context.HopDongs, "MaHopDong", "MaHopDong", nguoiOhopDong.MaHopDong);
            return View(nguoiOhopDong);
        }

        // GET: NguoiOhopDongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiOhopDong = await _context.NguoiOhopDongs.FindAsync(id);
            if (nguoiOhopDong == null)
            {
                return NotFound();
            }
            ViewData["MaHopDong"] = new SelectList(_context.HopDongs, "MaHopDong", "MaHopDong", nguoiOhopDong.MaHopDong);
            return View(nguoiOhopDong);
        }

        // POST: NguoiOhopDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNguoiO,MaHopDong,HoTen,Cccd,SoDienThoai,LaNguoiDaiDien")] NguoiOhopDong nguoiOhopDong)
        {
            if (id != nguoiOhopDong.MaNguoiO)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiOhopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiOhopDongExists(nguoiOhopDong.MaNguoiO))
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
            ViewData["MaHopDong"] = new SelectList(_context.HopDongs, "MaHopDong", "MaHopDong", nguoiOhopDong.MaHopDong);
            return View(nguoiOhopDong);
        }

        // GET: NguoiOhopDongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiOhopDong = await _context.NguoiOhopDongs
                .Include(n => n.MaHopDongNavigation)
                .FirstOrDefaultAsync(m => m.MaNguoiO == id);
            if (nguoiOhopDong == null)
            {
                return NotFound();
            }

            return View(nguoiOhopDong);
        }

        // POST: NguoiOhopDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiOhopDong = await _context.NguoiOhopDongs.FindAsync(id);
            if (nguoiOhopDong != null)
            {
                _context.NguoiOhopDongs.Remove(nguoiOhopDong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiOhopDongExists(int id)
        {
            return _context.NguoiOhopDongs.Any(e => e.MaNguoiO == id);
        }
    }
}
