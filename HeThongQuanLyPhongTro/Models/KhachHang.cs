namespace HeThongQuanLyPhongTro.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class KhachHang
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mã khách hàng")]
        public string MaKhachHang { get; set; }

        [Required]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }

        [Required]
        [Display(Name = "CCCD")]
        [StringLength(20)]
        public string CCCD { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        [Phone]
        public string SDT { get; set; }

        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Mã tài khoản (khóa phụ)")]
        public int? MaTaiKhoan { get; set; }
    }
}
