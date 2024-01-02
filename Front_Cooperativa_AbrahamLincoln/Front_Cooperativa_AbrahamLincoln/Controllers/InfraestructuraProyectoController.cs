using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InfraestructuraProyectoController : Controller
    {
        private readonly IConfiguration _configuration;
        public InfraestructuraProyectoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> InfraestructraProyecto()
        {

            List<IInfraestructura_Proyecto> infraestructura = new List<IInfraestructura_Proyecto>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync( "http://173.212.229.137:81/api/ListarComponentes/infraestructura_proyectos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    infraestructura = JsonConvert.DeserializeObject<List<IInfraestructura_Proyecto>>(respApi1);

                }
                ViewBag.InfraestructuraProyecto = new SelectList(infraestructura);

            }

            return View(infraestructura);

        }
    }
}
