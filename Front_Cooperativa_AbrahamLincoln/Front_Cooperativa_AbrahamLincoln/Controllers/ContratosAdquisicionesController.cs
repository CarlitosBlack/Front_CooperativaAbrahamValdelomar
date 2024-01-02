using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ContratosAdquisicionesController : Controller
    {
        private readonly IConfiguration _configuration;
        public ContratosAdquisicionesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ContratosAdquisiciones()
        {

            List<IContratos_Adquisiciones> contratosAdquisiciones = new List<IContratos_Adquisiciones>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/contratos_adquisiciones"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    contratosAdquisiciones = JsonConvert.DeserializeObject<List<IContratos_Adquisiciones>>(respApi1);

                }
                ViewBag.ContratosAdquisiciones = new SelectList(contratosAdquisiciones);

            }

            return View(contratosAdquisiciones);

        }
    }
}
