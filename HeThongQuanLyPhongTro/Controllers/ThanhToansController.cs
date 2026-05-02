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
    public class ThanhToansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThanhToansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThanhToans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ThanhToans.Include(t => t.MaHoaDonNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ThanhToans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToans
                .Include(t => t.MaHoaDonNavigation)
                .FirstOrDefaultAsync(m => m.MaThanhToan == id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            return View(thanhToan);
        }

        // GET: ThanhToans/Create
        public IActionResult Create()
        {
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon");
            return View();
        }

        // POST: ThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThanhToan,MaHoaDon,SoTien,NgayThanhToan,NoiDungChuyenKhoan,TrangThai")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhToan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon", thanhToan.MaHoaDon);
            return View(thanhToan);
        }

        // GET: ThanhToans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToans.FindAsync(id);
            if (thanhToan == null)
            {
                return NotFound();
            }
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon", thanhToan.MaHoaDon);
            return View(thanhToan);
        }

        // POST: ThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaThanhToan,MaHoaDon,SoTien,NgayThanhToan,NoiDungChuyenKhoan,TrangThai")] ThanhToan thanhToan)
        {
            if (id != thanhToan.MaThanhToan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhToan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhToanExists(thanhToan.MaThanhToan))
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
            ViewData["MaHoaDon"] = new SelectList(_context.HoaDons, "MaHoaDon", "MaHoaDon", thanhToan.MaHoaDon);
            return View(thanhToan);
        }

        // GET: ThanhToans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToans
                .Include(t => t.MaHoaDonNavigation)
                .FirstOrDefaultAsync(m => m.MaThanhToan == id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            return View(thanhToan);
        }

        // POST: ThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thanhToan = await _context.ThanhToans.FindAsync(id);
            if (thanhToan != null)
            {
                _context.ThanhToans.Remove(thanhToan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhToanExists(int id)
        {
            return _context.ThanhToans.Any(e => e.MaThanhToan == id);
        }
    }
}
