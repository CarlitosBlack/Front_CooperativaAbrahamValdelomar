using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class PedagogicosProyectosController : Controller
    {
        private readonly IConfiguration _configuration;
        public PedagogicosProyectosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> PedagogicosProyectos()
        {

            List<IPedagogicos_Proyecto> pedagogicos = new List<IPedagogicos_Proyecto>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/pedagogicos_proyectos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    pedagogicos = JsonConvert.DeserializeObject<List<IPedagogicos_Proyecto>>(respApi1);

                }
                ViewBag.PedagogicosProyectos = new SelectList(pedagogicos);

            }

            return View(pedagogicos);

        }
    }
}
