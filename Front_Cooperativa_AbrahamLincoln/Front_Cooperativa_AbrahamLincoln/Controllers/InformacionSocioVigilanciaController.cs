using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Front_Cooperativa_AbrahamLincoln.Models;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InformacionSocioVigilanciaController : Controller
    {
        private readonly IConfiguration _configuration;
        public InformacionSocioVigilanciaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> InformacionSocioVigilancia()
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IInfo_Socio_Vigilancia> infoSocioVigi = new List<IInfo_Socio_Vigilancia>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync( "http://173.212.229.137:81/api/ListarComponentes/informacion_socio_vigilancia"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    infoSocioVigi = JsonConvert.DeserializeObject<List<IInfo_Socio_Vigilancia>>(respApi1);

                }
                ViewBag.InfoSocioVigilancia = new SelectList(infoSocioVigi);

            }

            return View(infoSocioVigi);

        }
    }
}
