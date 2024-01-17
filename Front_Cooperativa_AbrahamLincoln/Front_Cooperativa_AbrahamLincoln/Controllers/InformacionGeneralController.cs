using Front_Cooperativa_AbrahamLincoln.Entidades;
using Front_Cooperativa_AbrahamLincoln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InformacionGeneralController : Controller
    {
        private readonly IConfiguration _configuration;
        public InformacionGeneralController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> InformacionGeneral()
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IInfo_General> infoGeneral = new List<IInfo_General>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/informacion_general"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    infoGeneral = JsonConvert.DeserializeObject<List<IInfo_General>>(respApi1);

                }
                ViewBag.InfoGeneral = new SelectList(infoGeneral);

            }

            return View(infoGeneral);

        }
    }
}
