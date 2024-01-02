using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;


namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ConsultaController : Controller
    {
        
        public  IActionResult Index()
        {
            
            
            //ViewData["NombreUsuario"] = nombreUsuario;
            //TempData["NombreUsuario"] = nombreUsuario1;
            return View();
        }

        public IActionResult Privacy5()
        {
            return View();
        }

        [HttpPost] // O [HttpGet] dependiendo de cómo manejes la solicitud AJAX
        public IActionResult Index(string nombre)
        {

            TempData["NombreUsuario"] = nombre;
           
            return View(TempData["NombreUsuario"]);
            //return RedirectToAction("Index1", "Consulta");
        }



    }
}
