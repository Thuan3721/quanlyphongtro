using HeThongQuanLyPhongTro.Data;
using HeThongQuanLyPhongTro.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class PhongController : AdminControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhongController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Edit(int id)
        {
            var phong = _context.Phongs.Find(id);

            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }
        public IActionResult Index(string searchString, string trangThai)
        {
            var dsPhong = _context.Phongs.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                dsPhong = dsPhong.Where(p => p.TenPhong.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(trangThai))
            {
                dsPhong = dsPhong.Where(p => p.TrangThai == trangThai);
            }

            return View(dsPhong.ToList());
        }
        public IActionResult Delete(int id)
        {
            var phong = _context.Phongs.Find(id);

            if (phong == null)
            {
                return NotFound();
            }

            _context.Phongs.Remove(phong);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Phongs.Update(phong);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phong);
        }
        [HttpPost]
        public IActionResult Create(Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Phongs.Add(phong);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phong);
        }
    }
}