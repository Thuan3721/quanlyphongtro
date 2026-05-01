using System;
using System.Collections.Generic;

namespace HeThongQuanLyPhongTro.Models;

public partial class NguoiOhopDong
{
    public int MaNguoiO { get; set; }

    public int MaHopDong { get; set; }

    public string? HoTen { get; set; }

    public string? Cccd { get; set; }

    public string? SoDienThoai { get; set; }

    public bool? LaNguoiDaiDien { get; set; }

    public virtual HopDong MaHopDongNavigation { get; set; } = null!;
}
