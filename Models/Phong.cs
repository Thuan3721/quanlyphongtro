using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HeThongQuanLyPhongTro.Models;

namespace HeThongQuanLyPhongTro.Models
{
    // Bảng phòng: quản lý các phòng trọ
    public class Phong
    {
        [Key]
        public int MaPhong { get; set; }

        public string TenPhong { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá phòng không được để trống")]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaPhong { get; set; }

        public double? DienTich { get; set; }

        public string? TrangThai { get; set; } = "Trống"; // Trống / Đã thuê

        // Số người ở (để tính phí dịch vụ 200k/người)
        public int? SoLuongNguoiO { get; set; } = 1;

        public int MaToaNha { get; set; }

        // THÊM THUỘC TÍNH NÀY (đã có trong SQL)
        public int MaChuTro { get; set; }

        [ForeignKey("MaToaNha")]
        public virtual ToaNha ToaNha { get; set; }

        // THÊM NAVIGATION CHO CHỦ TRỌ
        [ForeignKey("MaChuTro")]
        public virtual TaiKhoan ChuTro { get; set; }

        // THÊM: Mối quan hệ đến bảng CoSoVatChat
        public virtual ICollection<CoSoVatChat> CoSoVatChats { get; set; } = new List<CoSoVatChat>();

        // =================================================================
        // 🛠️ MẸO ĐỂ SỬA LỖI MẤT KẾT NỐI COSO (GIỮ LOGIC CHO CONTROLLER VÀ VIEW CŨ)
        // =================================================================

        [NotMapped] // Dòng này giúp Entity Framework biết đây là thuộc tính ảo, không tạo cột trong SQL Server
        public int MaCoSo
        {
            get => MaToaNha;
            set => MaToaNha = value;
        }

        [NotMapped]
        public virtual ToaNha CoSo
        {
            get => ToaNha;
            set => ToaNha = value;
        }

        [NotMapped]
        public string TenCoSo => ToaNha != null ? ToaNha.TenToaNha : string.Empty;
    }
}