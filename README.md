# quanlyphongtro
# Hệ Thống Quản Lý Phòng Trọ

Website quản lý và đăng tin cho thuê phòng trọ, xây dựng bằng ASP.NET Core.

## Chức năng chính

- Đăng ký, đăng nhập, phân quyền (chủ trọ / người thuê / quản trị viên)
- Đăng tin cho thuê phòng kèm hình ảnh
- Tìm kiếm, lọc phòng theo giá, khu vực, diện tích
- Quản lý phòng, khách thuê, hợp đồng
- Quản lý hóa đơn (điện, nước, tiền phòng)
- Thống kê, báo cáo

## Công nghệ sử dụng

- ASP.NET Core MVC (C#)
- Entity Framework Core
- SQL Server
- HTML, CSS, JavaScript, Bootstrap

## Cách chạy dự án

1. Clone repo:
   ```
   git clone https://github.com/Thuan3721/quanlyphongtro.git
   ```
2. Mở file `.sln` bằng Visual Studio 2022
3. Sửa chuỗi kết nối database trong `appsettings.json`
4. Chạy migration để tạo database:
   ```
   Update-Database
   ```
5. Nhấn F5 để chạy
