using Microsoft.AspNetCore.Mvc;
using HeThongQuanLyPhongTro.Models;
using System.Collections.Generic;
using System.Linq;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class PhongController : Controller
    {
        private static List<Phong> _phongs = new List<Phong>
        {
            new Phong{ Id=1, MaPhong="P001", TenPhong="Phòng 101", SoLuongToiDa=2, DienTich=20, Gia=2000000, TinhTrang="Trống" },
            new Phong{ Id=2, MaPhong="P002", TenPhong="Phòng 102", SoLuongToiDa=3, DienTich=30, Gia=3000000, TinhTrang="Đã thuê" }
        };

        public IActionResult Index()
        {
            return View(_phongs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Phong phong)
        {
            if (ModelState.IsValid)
            {
                phong.Id = _phongs.Any() ? _phongs.Max(p => p.Id) + 1 : 1;
                _phongs.Add(phong);
                return RedirectToAction(nameof(Index));
            }
            return View(phong);
        }

        public IActionResult Edit(int id)
        {
            var p = _phongs.FirstOrDefault(x => x.Id == id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Phong phong)
        {
            if (ModelState.IsValid)
            {
                var existing = _phongs.FirstOrDefault(x => x.Id == phong.Id);
                if (existing == null) return NotFound();
                existing.MaPhong = phong.MaPhong;
                existing.TenPhong = phong.TenPhong;
                existing.SoLuongToiDa = phong.SoLuongToiDa;
                existing.DienTich = phong.DienTich;
                existing.Gia = phong.Gia;
                existing.TinhTrang = phong.TinhTrang;
                return RedirectToAction(nameof(Index));
            }
            return View(phong);
        }

        public IActionResult Details(int id)
        {
            var p = _phongs.FirstOrDefault(x => x.Id == id);
            if (p == null) return NotFound();
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            var p = _phongs.FirstOrDefault(x => x.Id == id);
            if (p != null) _phongs.Remove(p);
            return RedirectToAction(nameof(Index));
        }
    }
}
