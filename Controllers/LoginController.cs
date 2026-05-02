using HeThongQuanLyPhongTro.Data;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string tenDangNhap, string matKhau)
        {
            var user = _context.TaiKhoan
                .FirstOrDefault(x =>
                    x.TenDangNhap == tenDangNhap &&
                    x.MatKhau == matKhau);

            if (user == null)
            {
                ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.MaTaiKhoan);
            HttpContext.Session.SetString("Role", user.VaiTro);
            HttpContext.Session.SetString("Username", user.TenDangNhap);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}