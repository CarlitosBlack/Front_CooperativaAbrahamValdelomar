using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class TalleresInduccionController : Controller
    {
        private readonly IConfiguration _configuration;
        public TalleresInduccionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> TalleresInduccion()
        {

            List<ITalleres_Induccion> talleresInduccion = new List<ITalleres_Induccion>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/talleres_de_induccion"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    talleresInduccion = JsonConvert.DeserializeObject<List<ITalleres_Induccion>>(respApi1);

                }
                ViewBag.TalleresInduccion = new SelectList(talleresInduccion);

            }

            return View(talleresInduccion);

        }
    }
}
