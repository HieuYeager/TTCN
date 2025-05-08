using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Hotel_Mng .DAL;
using Hotel_Mng.Models;

namespace Hotel_Mng.Controllers
{   
    public class AuthController : Controller
    {
        private HotelDbContext db = new HotelDbContext();

        // GET: Auth/Login
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string hash = ComputeHash(password);
            var user = db.Accounts.FirstOrDefault(a => a.Username == username && a.PasswordHash == hash && a.Status == "Active");
            if (user != null)
            {
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View();
        }

        // GET: Auth/Register
        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Mật khẩu xác nhận không khớp.";
                return View();
            }

            if (db.Accounts.Any(a => a.Username == username))
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại.";
                return View();
            }

            var newAccount = new Account
            {
                Username = username,
                PasswordHash = ComputeHash(password),
                Role = "Customer",
                Status = "Active"
            };

            db.Accounts.Add(newAccount);
            db.SaveChanges();

            return RedirectToAction("Login");
        }

        // GET: Auth/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        private string ComputeHash(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return string.Concat(data.Select(b => b.ToString("x2")));
            }
        }
    }
}
