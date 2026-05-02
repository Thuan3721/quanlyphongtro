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
    public class CoSoVatChatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoSoVatChatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoSoVatChats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CoSoVatChats.Include(c => c.MaPhongNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CoSoVatChats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSoVatChat = await _context.CoSoVatChats
                .Include(c => c.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaCsvc == id);
            if (coSoVatChat == null)
            {
                return NotFound();
            }

            return View(coSoVatChat);
        }

        // GET: CoSoVatChats/Create
        public IActionResult Create()
        {
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong");
            return View();
        }

        // POST: CoSoVatChats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCsvc,MaPhong,TenThietBi,SoLuong,TinhTrang")] CoSoVatChat coSoVatChat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coSoVatChat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", coSoVatChat.MaPhong);
            return View(coSoVatChat);
        }

        // GET: CoSoVatChats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSoVatChat = await _context.CoSoVatChats.FindAsync(id);
            if (coSoVatChat == null)
            {
                return NotFound();
            }
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", coSoVatChat.MaPhong);
            return View(coSoVatChat);
        }

        // POST: CoSoVatChats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCsvc,MaPhong,TenThietBi,SoLuong,TinhTrang")] CoSoVatChat coSoVatChat)
        {
            if (id != coSoVatChat.MaCsvc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coSoVatChat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoSoVatChatExists(coSoVatChat.MaCsvc))
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
            ViewData["MaPhong"] = new SelectList(_context.Phongs, "MaPhong", "MaPhong", coSoVatChat.MaPhong);
            return View(coSoVatChat);
        }

        // GET: CoSoVatChats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSoVatChat = await _context.CoSoVatChats
                .Include(c => c.MaPhongNavigation)
                .FirstOrDefaultAsync(m => m.MaCsvc == id);
            if (coSoVatChat == null)
            {
                return NotFound();
            }

            return View(coSoVatChat);
        }

        // POST: CoSoVatChats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coSoVatChat = await _context.CoSoVatChats.FindAsync(id);
            if (coSoVatChat != null)
            {
                _context.CoSoVatChats.Remove(coSoVatChat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoSoVatChatExists(int id)
        {
            return _context.CoSoVatChats.Any(e => e.MaCsvc == id);
        }
    }
}
