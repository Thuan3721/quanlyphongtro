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
    public class HopDongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopDongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HopDongs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HopDongs.Include(h => h.MaKhachHangNavigation).Include(h => h.MaPhongNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HopDongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDongs
                .Include(h => h.MaKhachHangNavigation)
                .Include(h => h.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaHopDong == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // GET: HopDongs/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang");
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong");
            return View();
        }

        // POST: HopDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHopDong,MaPhong,MaKhachHang,NgayBatDau,NgayKetThuc,TienCoc,FileHopDong,TrangThai,ThoiHan")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", hopDong.MaKhachHang);
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", hopDong.MaPhong);
            return View(hopDong);
        }

        // GET: HopDongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", hopDong.MaKhachHang);
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", hopDong.MaPhong);
            return View(hopDong);
        }

        // POST: HopDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHopDong,MaPhong,MaKhachHang,NgayBatDau,NgayKetThuc,TienCoc,FileHopDong,TrangThai,ThoiHan")] HopDong hopDong)
        {
            if (id != hopDong.MaHopDong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongExists(hopDong.MaHopDong))
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
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHangs, "MaKhachHang", "MaKhachHang", hopDong.MaKhachHang);
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", hopDong.MaPhong);
            return View(hopDong);
        }

        // GET: HopDongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDongs
                .Include(h => h.MaKhachHangNavigation)
                .Include(h => h.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaHopDong == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // POST: HopDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hopDong = await _context.HopDongs.FindAsync(id);
            if (hopDong != null)
            {
                _context.HopDongs.Remove(hopDong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopDongExists(int id)
        {
            return _context.HopDongs.Any(e => e.MaHopDong == id);
        }
    }
}
