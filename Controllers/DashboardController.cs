using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyPhongTro.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == "Admin")
            {
                return View("AdminDashboard");
            }

            return View("KhachDashboard");
        }
    }
}