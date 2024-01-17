using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Front_Cooperativa_AbrahamLincoln.Models;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class EspecialesController : Controller
    {
        private readonly IConfiguration _configuration;
        public EspecialesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Especiales()
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IEspeciales> especiales = new List<IEspeciales>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/especiales"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    especiales = JsonConvert.DeserializeObject<List<IEspeciales>>(respApi1);

                }
                ViewBag.Especiales = new SelectList(especiales);

            }

            return View(especiales);

        }
    }
}
