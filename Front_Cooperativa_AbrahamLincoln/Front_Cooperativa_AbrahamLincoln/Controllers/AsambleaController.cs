using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class AsambleaController : Controller
    {
        private readonly IConfiguration _configuration;
        public AsambleaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Asamblea()
        {

            List<IAsambleas> asambleas = new List<IAsambleas>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/asambleas"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    asambleas = JsonConvert.DeserializeObject<List<IAsambleas>>(respApi1);
                    
                }
                ViewBag.Asambleas = new SelectList(asambleas);

            }

            return View(asambleas);

        }
    }
}
