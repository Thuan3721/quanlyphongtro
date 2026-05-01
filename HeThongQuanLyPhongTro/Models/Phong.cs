using System;
using System.Collections.Generic;

namespace HeThongQuanLyPhongTro.Models;

public partial class Phong
{
    public int MaPhong { get; set; }

    public int MaCoSo { get; set; }

    public string TenPhong { get; set; } = null!;

    public decimal GiaPhong { get; set; }

    public double DienTich { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    public virtual ICollection<CoSoVatChat> CoSoVatChats { get; set; } = new List<CoSoVatChat>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual CoSo MaCoSoNavigation { get; set; } = null!;
}
