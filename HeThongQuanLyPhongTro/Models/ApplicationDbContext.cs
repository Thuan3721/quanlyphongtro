using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyPhongTro.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiDang> BaiDangs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<CoSo> CoSos { get; set; }

    public virtual DbSet<CoSoVatChat> CoSoVatChats { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HopDong> HopDongs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NguoiOhopDong> NguoiOhopDongs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiDang>(entity =>
        {
            entity.HasKey(e => e.MaBaiDang).HasName("PK__BaiDang__BF5D50C56DDA99C1");

            entity.ToTable("BaiDang");

            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.NgayDang)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TieuDe).HasMaxLength(255);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Hiển thị");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BaiDang_Phong");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__ChiTietH__CDF0A1149497A23F");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.LoaiKhoanThu).HasMaxLength(100);
            entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");
        });

        modelBuilder.Entity<CoSo>(entity =>
        {
            entity.HasKey(e => e.MaCoSo).HasName("PK__CoSo__152D0634E50E960C");

            entity.ToTable("CoSo");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenCoSo).HasMaxLength(100);
        });

        modelBuilder.Entity<CoSoVatChat>(entity =>
        {
            entity.HasKey(e => e.MaCsvc).HasName("PK__CoSoVatC__1E75CC22AD946FEA");

            entity.ToTable("CoSoVatChat");

            entity.Property(e => e.MaCsvc).HasColumnName("MaCSVC");
            entity.Property(e => e.TenThietBi).HasMaxLength(100);
            entity.Property(e => e.TinhTrang).HasMaxLength(100);

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.CoSoVatChats)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CSVC_Phong");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13B5A4BA7DC");

            entity.ToTable("HoaDon");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Chưa thanh toán");

            entity.HasOne(d => d.MaHopDongNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaHopDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_HopDong");
        });

        modelBuilder.Entity<HopDong>(entity =>
        {
            entity.HasKey(e => e.MaHopDong).HasName("PK__HopDong__36DD4342806E75D6");

            entity.ToTable("HopDong");

            entity.Property(e => e.FileHopDong).HasMaxLength(255);
            entity.Property(e => e.ThoiHan).HasMaxLength(50);
            entity.Property(e => e.TienCoc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Hiệu lực");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HopDong_KhachHang");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HopDong_Phong");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5BA5514E6");

            entity.ToTable("KhachHang");

            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK_KhachHang_TaiKhoan");
        });

        modelBuilder.Entity<NguoiOhopDong>(entity =>
        {
            entity.HasKey(e => e.MaNguoiO).HasName("PK__NguoiOHo__B260BFB38AFC5F50");

            entity.ToTable("NguoiOHopDong");

            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("CCCD");
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.LaNguoiDaiDien).HasDefaultValue(false);
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);

            entity.HasOne(d => d.MaHopDongNavigation).WithMany(p => p.NguoiOhopDongs)
                .HasForeignKey(d => d.MaHopDong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiOHopDong_HopDong");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__Phong__20BD5E5B8CDA2FB7");

            entity.ToTable("Phong");

            entity.Property(e => e.GiaPhong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenPhong).HasMaxLength(50);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .HasDefaultValue("Trống");

            entity.HasOne(d => d.MaCoSoNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaCoSo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_CoSo");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C65292FEE0BF5");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC067874902").IsUnique();

            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Hoạt động");
            entity.Property(e => e.VaiTro).HasMaxLength(20);
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__ThanhToa__D4B2584486A60876");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");
            entity.Property(e => e.NoiDungChuyenKhoan).HasMaxLength(255);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(30);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_HoaDon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
