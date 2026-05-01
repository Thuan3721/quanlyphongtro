using Microsoft.AspNetCore.Mvc;
using HeThongQuanLyPhongTro.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class KhachHangController : Controller
    {
        private static List<KhachHang> _khachHangs = new List<KhachHang>
        {
            new KhachHang{ Id=1, MaKhachHang="KH001", HoTen="Nguyễn Văn A", CCCD="012345678901", SDT="0909123456", DiaChi="Hà Nội", GioiTinh="Nam", NgaySinh=new DateTime(1990,1,1), Email="a@example.com", MaTaiKhoan=1 },
            new KhachHang{ Id=2, MaKhachHang="KH002", HoTen="Trần Thị B", CCCD="098765432109", SDT="0912345678", DiaChi="Hải Phòng", GioiTinh="Nữ", NgaySinh=new DateTime(1995,5,5), Email="b@example.com", MaTaiKhoan=2 }
        };

        public IActionResult Index()
        {
            return View(_khachHangs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                kh.Id = _khachHangs.Any() ? _khachHangs.Max(x => x.Id) + 1 : 1;
                _khachHangs.Add(kh);
                return RedirectToAction(nameof(Index));
            }
            return View(kh);
        }

        public IActionResult Edit(int id)
        {
            var kh = _khachHangs.FirstOrDefault(x => x.Id == id);
            if (kh == null) return NotFound();
            return View(kh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var existing = _khachHangs.FirstOrDefault(x => x.Id == kh.Id);
                if (existing == null) return NotFound();
                existing.MaKhachHang = kh.MaKhachHang;
                existing.HoTen = kh.HoTen;
                existing.CCCD = kh.CCCD;
                existing.SDT = kh.SDT;
                existing.DiaChi = kh.DiaChi;
                existing.GioiTinh = kh.GioiTinh;
                existing.NgaySinh = kh.NgaySinh;
                existing.Email = kh.Email;
                existing.MaTaiKhoan = kh.MaTaiKhoan;
                return RedirectToAction(nameof(Index));
            }
            return View(kh);
        }

        public IActionResult Details(int id)
        {
            var kh = _khachHangs.FirstOrDefault(x => x.Id == id);
            if (kh == null) return NotFound();
            return View(kh);
        }

        public IActionResult Delete(int id)
        {
            var kh = _khachHangs.FirstOrDefault(x => x.Id == id);
            if (kh != null) _khachHangs.Remove(kh);
            return RedirectToAction(nameof(Index));
        }
    }
}
