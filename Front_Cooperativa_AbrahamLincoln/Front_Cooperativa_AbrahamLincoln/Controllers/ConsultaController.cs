using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ConsultaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            return View() ;
        }

        public IActionResult Privacy5()
        {
            return View();
        }
    }
}
