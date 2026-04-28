using Microsoft.EntityFrameworkCore;
using HeThongQuanLyPhongTro.Models;
namespace HeThongQuanLyPhongTro.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Phong> Phongs { get; set; }
    }
}
