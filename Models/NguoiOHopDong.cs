using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyPhongTro.Models
{
    public class NguoiOHopDong
    {
        [Key]
        public int MaNguoiO { get; set; }

        public int MaHopDong { get; set; }

        public string? HoTen { get; set; }

        public string? CCCD { get; set; }

        public string? SoDienThoai { get; set; }

        public bool? LaNguoiDaiDien { get; set; } = false;
    }
}