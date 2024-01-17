using Front_Cooperativa_AbrahamLincoln.Entidades;
using Front_Cooperativa_AbrahamLincoln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ActaSesionesVigilanciaController : Controller
    {
        private readonly IConfiguration _configuration;
        public ActaSesionesVigilanciaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ActaSesionesVigilancia()
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IActa_Sesiones_Vigilancia> actaSesionesVigi = new List<IActa_Sesiones_Vigilancia>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/actas_sesiones_vigilancia"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    actaSesionesVigi = JsonConvert.DeserializeObject<List<IActa_Sesiones_Vigilancia>>(respApi1);

                }
                ViewBag.ActaSesionesVigi = new SelectList(actaSesionesVigi);

            }

            return View(actaSesionesVigi);

        }
    }
}
