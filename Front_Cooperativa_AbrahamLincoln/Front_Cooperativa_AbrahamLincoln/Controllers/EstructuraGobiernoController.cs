using Front_Cooperativa_AbrahamLincoln.Entidades;
using Front_Cooperativa_AbrahamLincoln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class EstructuraGobiernoController : Controller
    {
        private readonly IConfiguration _configuration;
        public EstructuraGobiernoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> EstructuraGobierno()
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IEstructura_Gobierno> estructura = new List<IEstructura_Gobierno>();
            //string valorVariable = _configuration["URL_CONTROLLER"];

            using (var listarComponentes = new HttpClient())
            {

                //using (var carga = await listarComponentes.GetAsync(valorVariable + "/api/ListarComponentes/estructura_gobierno"))
                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/estructura_gobierno"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    estructura = JsonConvert.DeserializeObject<List<IEstructura_Gobierno>>(respApi);
                    //ViewBag.Estructura = new SelectList(estructura);
                }
                ViewBag.Estructura = new SelectList(estructura);


            }
            return View(estructura);
        }
    }
}
