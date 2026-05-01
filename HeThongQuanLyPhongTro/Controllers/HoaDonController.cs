using Microsoft.AspNetCore.Mvc;
using HeThongQuanLyPhongTro.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class HoaDonController : Controller
    {
        private static List<HoaDon> _hoaDons = new List<HoaDon>
        {
            new HoaDon{ Id=1, MaHoaDon="HDN001", MaHopDong="HD001", Thang=1, Nam=2024, TongTien=2000000, TrangThaiThanhToan="Chưa thanh toán", NgayTao=new DateTime(2024,1,5), NoiDungThanhToan="Tiền phòng tháng 1" },
            new HoaDon{ Id=2, MaHoaDon="HDN002", MaHopDong="HD002", Thang=2, Nam=2024, TongTien=3000000, TrangThaiThanhToan="Đã thanh toán", NgayThanhToan=new DateTime(2024,2,10), NgayTao=new DateTime(2024,2,5), NoiDungThanhToan="Tiền phòng tháng 2" }
        };

        public IActionResult Index()
        {
            return View(_hoaDons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HoaDon hd)
        {
            if (ModelState.IsValid)
            {
                hd.Id = _hoaDons.Any() ? _hoaDons.Max(x => x.Id) + 1 : 1;
                hd.NgayTao = DateTime.Now;
                _hoaDons.Add(hd);
                return RedirectToAction(nameof(Index));
            }
            return View(hd);
        }

        public IActionResult Edit(int id)
        {
            var hd = _hoaDons.FirstOrDefault(x => x.Id == id);
            if (hd == null) return NotFound();
            return View(hd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HoaDon hd)
        {
            if (ModelState.IsValid)
            {
                var existing = _hoaDons.FirstOrDefault(x => x.Id == hd.Id);
                if (existing == null) return NotFound();
                existing.MaHoaDon = hd.MaHoaDon;
                existing.MaHopDong = hd.MaHopDong;
                existing.Thang = hd.Thang;
                existing.Nam = hd.Nam;
                existing.TongTien = hd.TongTien;
                existing.TrangThaiThanhToan = hd.TrangThaiThanhToan;
                existing.NgayThanhToan = hd.NgayThanhToan;
                existing.NoiDungThanhToan = hd.NoiDungThanhToan;
                // giữ NgayTao
                return RedirectToAction(nameof(Index));
            }
            return View(hd);
        }

        public IActionResult Details(int id)
        {
            var hd = _hoaDons.FirstOrDefault(x => x.Id == id);
            if (hd == null) return NotFound();
            return View(hd);
        }

        public IActionResult Delete(int id)
        {
            var hd = _hoaDons.FirstOrDefault(x => x.Id == id);
            if (hd != null) _hoaDons.Remove(hd);
            return RedirectToAction(nameof(Index));
        }

        // Trả về view in để người dùng có thể dùng chức năng Print -> Save as PDF của trình duyệt
        public IActionResult Print(int id)
        {
            var hd = _hoaDons.FirstOrDefault(x => x.Id == id);
            if (hd == null) return NotFound();
            return View(hd);
        }
    }
}
