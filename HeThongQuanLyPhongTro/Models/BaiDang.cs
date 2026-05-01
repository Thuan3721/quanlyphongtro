using System;
using System.Collections.Generic;

namespace HeThongQuanLyPhongTro.Models;

public partial class BaiDang
{
    public int MaBaiDang { get; set; }

    public int MaPhong { get; set; }

    public string? TieuDe { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public DateTime? NgayDang { get; set; }

    public string? TrangThai { get; set; }

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
