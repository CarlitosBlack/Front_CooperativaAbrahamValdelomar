using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class CooperativaController : Controller
    {
        private readonly IConfiguration _configuration;
        public CooperativaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> cooperativa()
        {

            List<ICooperativa> cooperativa = new List<ICooperativa>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/cooperativa"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    cooperativa = JsonConvert.DeserializeObject<List<ICooperativa>>(respApi1);
                    
                }
                ViewBag.Cooperativa = new SelectList(cooperativa);

            }

            return View(cooperativa);
        
        }
    }
}
