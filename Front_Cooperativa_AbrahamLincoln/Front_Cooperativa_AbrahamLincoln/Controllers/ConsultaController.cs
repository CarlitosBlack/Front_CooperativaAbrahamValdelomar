using Front_Cooperativa_AbrahamLincoln.Entidades;
using Front_Cooperativa_AbrahamLincoln.Models;
using Front_Cooperativa_AbrahamLincoln.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    //[Authorize]
    public class ConsultaController : Controller
    {

        public IActionResult Index()
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            
                // Si el valor de la sesión no es nulo, convertirlo al tipo correcto (en este ejemplo, de bytes a string)
                var serializedData = Encoding.UTF8.GetString(sessionData);

            // Convertir el string serializado a un objeto de tu tipo
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
             
                ViewBag.Nombre = nombreUsuario.NombreUsuario;
            
            

            return View();
        }

        //public IActionResult Privacy5()
        //{
        //    return View();
        //}

        /*[HttpPost]*/// O [HttpGet] dependiendo de cómo manejes la solicitud AJAX
        //public IActionResult Index(ISharedService sharedService, string nombreUsuario)
        //public IActionResult Index( string nombre)
        //{
            //TempData["NombreUsuario"] = nombre;
            //return View(TempData["NombreUsuario"]);
            //return RedirectToAction("Index1", "Consulta");
            //Console.WriteLine(nombre);
            //var modelo = new SharedService();
            //{
            //    modelo.NombreUsuario = nombre;
            //}
            //sharedService.NombreUsuario = nombre;

            //string nombre = modelo.NombreUsuario;
            
                
                //Logeo datos = new Logeo();
                //datos.NombreUsuario = nombreUsuario;
                //ViewBag.Nombre = datos.NombreUsuario;
                    //}
                //}
                
                
            


            //var nombre = nombreUsuario;
            //ViewBag.Nombre = nombre;
        //    return View(ViewBag.Nombre);
        //}


    }
}
