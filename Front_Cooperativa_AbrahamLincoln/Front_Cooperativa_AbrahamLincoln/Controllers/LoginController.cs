using Microsoft.AspNetCore.Mvc;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class LoginController : Controller
    {
        

        public async Task<IActionResult> Login()
        {
            return View(); 
        }



    }
}
