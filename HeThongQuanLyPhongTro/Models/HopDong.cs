namespace HeThongQuanLyPhongTro.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HopDong
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mã hợp đồng")]
        public string MaHopDong { get; set; }

        [Required]
        [Display(Name = "Mã khách hàng")]
        public string MaKhachHang { get; set; }

        [Required]
        [Display(Name = "Mã phòng")]
        public string MaPhong { get; set; }

        [Required]
        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }

        [Display(Name = "Ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime? NgayKetThuc { get; set; }

        [Display(Name = "Tiền cọc (VNĐ)")]
        [DataType(DataType.Currency)]
        public decimal TienCoc { get; set; }

        [Display(Name = "Thời hạn (tháng)")]
        public int ThoiHan { get; set; }
    }
}
