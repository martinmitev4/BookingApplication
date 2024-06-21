using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers
{
    public class BookingListsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
