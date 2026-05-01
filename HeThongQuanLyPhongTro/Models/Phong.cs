namespace HeThongQuanLyPhongTro.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Phong
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mã phòng")]
        public string MaPhong { get; set; }

        [Required]
        [Display(Name = "Tên phòng")]
        public string TenPhong { get; set; }

        [Display(Name = "Số người tối đa")]
        public int SoLuongToiDa { get; set; }

        [Display(Name = "Diện tích (m²)")]
        public double DienTich { get; set; }

        [Display(Name = "Giá (VNĐ)")]
        public decimal Gia { get; set; }

        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }
    }
}
