using System;
using System.Collections.Generic;

namespace HeThongQuanLyPhongTro.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public int? MaTaiKhoan { get; set; }

    public string HoTen { get; set; } = null!;

    public string? Cccd { get; set; }

    public string SoDienThoai { get; set; } = null!;

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }
}
