using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ActaSesionesVigilanciaController : Controller
    {
        public async Task<IActionResult> ActaSesionesVigilancia()
        {

            List<IActa_Sesiones_Vigilancia> actaSesionesVigi = new List<IActa_Sesiones_Vigilancia>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/actas_sesiones_vigilancia"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    actaSesionesVigi = JsonConvert.DeserializeObject<List<IActa_Sesiones_Vigilancia>>(respApi1);

                }
                ViewBag.ActaSesionesVigi = new SelectList(actaSesionesVigi);

            }

            return View(actaSesionesVigi);

        }
    }
}
