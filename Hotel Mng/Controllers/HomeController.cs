using System.Linq;
using System.Web.Mvc;
using Hotel_Mng.DAL;

namespace Hotel_Mng.Controllers
{
    public class HomeController : Controller
    {
        private HotelDbContext db = new HotelDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page."; 

            return View();
        }


        //public ActionResult Index()
        //{
        //    var accounts = db.Accounts.ToList(); // Lấy danh sách account
        //    return View(accounts); // Truyền xuống View
        //}
    }
}
