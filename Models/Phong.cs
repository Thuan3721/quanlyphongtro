using System.ComponentModel.DataAnnotations;
namespace HeThongQuanLyPhongTro.Models
{
    public class Phong
    {
        [Key]
        public int MaPhong { get; set; }
        [Required(ErrorMessage = "Tên phòng không được để trống")]
        public string TenPhong { get; set; }
        [Required(ErrorMessage = "Giá phòng không được để trống")]
        [Range(1, 100000000, ErrorMessage = "Giá phòng phải lớn hơn 0")]
        public decimal GiaPhong { get; set; }
        [Required(ErrorMessage = "Diện tích không được để trống")]
        [Range(1, 1000, ErrorMessage = "Diện tích phải lớn hơn 0")]
        public double DienTich { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
        public string TrangThai { get; set; }
    }
}
