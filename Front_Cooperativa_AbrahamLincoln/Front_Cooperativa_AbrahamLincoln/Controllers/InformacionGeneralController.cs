using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InformacionGeneralController : Controller
    {
        public async Task<IActionResult> InformacionGeneral()
        {

            List<IInfo_General> infoGeneral = new List<IInfo_General>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/informacion_general"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    infoGeneral = JsonConvert.DeserializeObject<List<IInfo_General>>(respApi1);

                }
                ViewBag.InfoGeneral = new SelectList(infoGeneral);

            }

            return View(infoGeneral);

        }
    }
}
