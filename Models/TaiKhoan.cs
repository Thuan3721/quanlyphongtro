namespace HeThongQuanLyPhongTro.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TaiKhoan
    {
        [Key]
        public int MaTaiKhoan { get; set; }

        public required string TenDangNhap { get; set; }

        public required string MatKhau { get; set; }

        public required string VaiTro { get; set; }
    }
}
