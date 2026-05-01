using System;
using System.Collections.Generic;

namespace HeThongQuanLyPhongTro.Models;

public partial class HopDong
{
    public int MaHopDong { get; set; }

    public int MaPhong { get; set; }

    public int MaKhachHang { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public decimal TienCoc { get; set; }

    public string? FileHopDong { get; set; }

    public string? TrangThai { get; set; }

    public string? ThoiHan { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;

    public virtual ICollection<NguoiOhopDong> NguoiOhopDongs { get; set; } = new List<NguoiOhopDong>();
}
