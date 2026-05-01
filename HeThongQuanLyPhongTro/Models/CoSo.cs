using System;
using System.Collections.Generic;

namespace HeThongQuanLyPhongTro.Models;

public partial class CoSo
{
    public int MaCoSo { get; set; }

    public string TenCoSo { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
