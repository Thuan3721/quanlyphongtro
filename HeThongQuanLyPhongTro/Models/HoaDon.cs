namespace HeThongQuanLyPhongTro.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HoaDon
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mã hóa đơn")]
        public string MaHoaDon { get; set; }

        [Required]
        [Display(Name = "Mã hợp đồng")]
        public string MaHopDong { get; set; }

        [Required]
        [Range(1, 12)]
        [Display(Name = "Tháng")]
        public int Thang { get; set; }

        [Required]
        [Range(2000, 3000)]
        [Display(Name = "Năm")]
        public int Nam { get; set; }

        [Display(Name = "Tổng tiền (VNĐ)")]
        [DataType(DataType.Currency)]
        public decimal TongTien { get; set; }

        [Display(Name = "Trạng thái thanh toán")]
        public string TrangThaiThanhToan { get; set; }

        [Display(Name = "Ngày thanh toán")]
        [DataType(DataType.Date)]
        public DateTime? NgayThanhToan { get; set; }

        [Display(Name = "Nội dung thanh toán")]
        public string NoiDungThanhToan { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
