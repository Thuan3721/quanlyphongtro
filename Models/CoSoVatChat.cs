using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyPhongTro.Models
{
    public class CoSoVatChat
    {
        [Key]
        public int MaCSVC { get; set; }

        public int MaPhong { get; set; }

        public string? TenThietBi { get; set; }

        public int? SoLuong { get; set; }

        public string? TinhTrang { get; set; }
    }
}