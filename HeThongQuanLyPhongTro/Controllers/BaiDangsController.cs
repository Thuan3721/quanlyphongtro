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
    public class BaiDangsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaiDangsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaiDangs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BaiDangs.Include(b => b.MaPhongNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BaiDangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiDang = await _context.BaiDangs
                .Include(b => b.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaBaiDang == id);
            if (baiDang == null)
            {
                return NotFound();
            }

            return View(baiDang);
        }

        // GET: BaiDangs/Create
        public IActionResult Create()
        {
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong");
            return View();
        }

        // POST: BaiDangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBaiDang,MaPhong,TieuDe,MoTa,HinhAnh,NgayDang,TrangThai")] BaiDang baiDang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baiDang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", baiDang.MaPhong);
            return View(baiDang);
        }

        // GET: BaiDangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiDang = await _context.BaiDangs.FindAsync(id);
            if (baiDang == null)
            {
                return NotFound();
            }
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", baiDang.MaPhong);
            return View(baiDang);
        }

        // POST: BaiDangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBaiDang,MaPhong,TieuDe,MoTa,HinhAnh,NgayDang,TrangThai")] BaiDang baiDang)
        {
            if (id != baiDang.MaBaiDang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baiDang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaiDangExists(baiDang.MaBaiDang))
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
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", baiDang.MaPhong);
            return View(baiDang);
        }

        // GET: BaiDangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiDang = await _context.BaiDangs
                .Include(b => b.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaBaiDang == id);
            if (baiDang == null)
            {
                return NotFound();
            }

            return View(baiDang);
        }

        // POST: BaiDangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baiDang = await _context.BaiDangs.FindAsync(id);
            if (baiDang != null)
            {
                _context.BaiDangs.Remove(baiDang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaiDangExists(int id)
        {
            return _context.BaiDangs.Any(e => e.MaBaiDang == id);
        }
    }
}
