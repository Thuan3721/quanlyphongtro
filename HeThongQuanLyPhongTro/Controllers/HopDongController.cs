using Microsoft.AspNetCore.Mvc;
using HeThongQuanLyPhongTro.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class HopDongController : Controller
    {
        private static List<HopDong> _hopDongs = new List<HopDong>
        {
            new HopDong{ Id=1, MaHopDong="HD001", MaKhachHang="KH001", MaPhong="P001", NgayBatDau=new DateTime(2024,1,1), NgayKetThuc=new DateTime(2025,1,1), TienCoc=1000000, ThoiHan=12 },
            new HopDong{ Id=2, MaHopDong="HD002", MaKhachHang="KH002", MaPhong="P002", NgayBatDau=new DateTime(2024,6,1), NgayKetThuc=new DateTime(2025,6,1), TienCoc=1500000, ThoiHan=12 }
        };

        public IActionResult Index()
        {
            return View(_hopDongs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HopDong hd)
        {
            if (ModelState.IsValid)
            {
                hd.Id = _hopDongs.Any() ? _hopDongs.Max(x => x.Id) + 1 : 1;
                _hopDongs.Add(hd);
                return RedirectToAction(nameof(Index));
            }
            return View(hd);
        }

        public IActionResult Edit(int id)
        {
            var hd = _hopDongs.FirstOrDefault(x => x.Id == id);
            if (hd == null) return NotFound();
            return View(hd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HopDong hd)
        {
            if (ModelState.IsValid)
            {
                var existing = _hopDongs.FirstOrDefault(x => x.Id == hd.Id);
                if (existing == null) return NotFound();
                existing.MaHopDong = hd.MaHopDong;
                existing.MaKhachHang = hd.MaKhachHang;
                existing.MaPhong = hd.MaPhong;
                existing.NgayBatDau = hd.NgayBatDau;
                existing.NgayKetThuc = hd.NgayKetThuc;
                existing.TienCoc = hd.TienCoc;
                existing.ThoiHan = hd.ThoiHan;
                return RedirectToAction(nameof(Index));
            }
            return View(hd);
        }

        public IActionResult Details(int id)
        {
            var hd = _hopDongs.FirstOrDefault(x => x.Id == id);
            if (hd == null) return NotFound();
            return View(hd);
        }

        public IActionResult Delete(int id)
        {
            var hd = _hopDongs.FirstOrDefault(x => x.Id == id);
            if (hd != null) _hopDongs.Remove(hd);
            return RedirectToAction(nameof(Index));
        }
    }
}
