using System.Linq;
using System.Web.Mvc;
using Hotel_Mng.DAL;

namespace Hotel_Mng.Controllers
{
    public class AccountController : Controller
    {
        private HotelDbContext db = new HotelDbContext();

        public ActionResult Index()
        {
            var accounts = db.Accounts.ToList(); // Lấy danh sách account
            return View(accounts); // Truyền xuống View
        }
    }
}
