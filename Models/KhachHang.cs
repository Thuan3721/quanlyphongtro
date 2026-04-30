using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyPhongTro.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKhachHang { get; set; }
        public int? MaTaiKhoan { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string? CCCD { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
    }
}