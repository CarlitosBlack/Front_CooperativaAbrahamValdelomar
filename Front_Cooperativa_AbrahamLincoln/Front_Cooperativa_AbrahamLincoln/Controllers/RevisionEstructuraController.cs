using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Front_Cooperativa_AbrahamLincoln.Models;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class RevisionEstructuraController : Controller
    {
        private readonly IConfiguration _configuration;
        public RevisionEstructuraController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> RevisionEstructura()
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IRevision_Estructura> revisionEstructura = new List<IRevision_Estructura>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync( "http://173.212.229.137:81/api/ListarComponentes/revision_estructura"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    revisionEstructura = JsonConvert.DeserializeObject<List<IRevision_Estructura>>(respApi1);

                }

            }

            return View(revisionEstructura);
        }
    }
}
