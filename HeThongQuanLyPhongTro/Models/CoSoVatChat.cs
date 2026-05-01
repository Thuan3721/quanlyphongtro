using System;
using System.Collections.Generic;

namespace HeThongQuanLyPhongTro.Models;

public partial class CoSoVatChat
{
    public int MaCsvc { get; set; }

    public int MaPhong { get; set; }

    public string? TenThietBi { get; set; }

    public int? SoLuong { get; set; }

    public string? TinhTrang { get; set; }

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
