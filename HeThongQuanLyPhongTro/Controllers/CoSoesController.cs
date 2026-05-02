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
    public class CoSoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoSoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoSoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoSos.ToListAsync());
        }

        // GET: CoSoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.CoSos
                .FirstOrDefaultAsync(m => m.MaCoSo == id);
            if (coSo == null)
            {
                return NotFound();
            }

            return View(coSo);
        }

        // GET: CoSoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoSoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCoSo,TenCoSo,DiaChi,MoTa")] CoSo coSo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coSo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coSo);
        }

        // GET: CoSoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.CoSos.FindAsync(id);
            if (coSo == null)
            {
                return NotFound();
            }
            return View(coSo);
        }

        // POST: CoSoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCoSo,TenCoSo,DiaChi,MoTa")] CoSo coSo)
        {
            if (id != coSo.MaCoSo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coSo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoSoExists(coSo.MaCoSo))
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
            return View(coSo);
        }

        // GET: CoSoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coSo = await _context.CoSos
                .FirstOrDefaultAsync(m => m.MaCoSo == id);
            if (coSo == null)
            {
                return NotFound();
            }

            return View(coSo);
        }

        // POST: CoSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coSo = await _context.CoSos.FindAsync(id);
            if (coSo != null)
            {
                _context.CoSos.Remove(coSo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoSoExists(int id)
        {
            return _context.CoSos.Any(e => e.MaCoSo == id);
        }
    }
}
