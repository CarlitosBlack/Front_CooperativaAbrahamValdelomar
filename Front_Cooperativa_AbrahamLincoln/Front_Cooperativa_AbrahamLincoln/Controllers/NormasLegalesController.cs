using Microsoft.AspNetCore.Mvc;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class NormasLegalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NormasLegales()
        {
            return View();
        }
    }
}
