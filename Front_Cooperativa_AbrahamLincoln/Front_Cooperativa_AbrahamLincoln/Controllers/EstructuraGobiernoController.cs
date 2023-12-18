using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class EstructuraGobiernoController : Controller
    {
        public async Task<IActionResult> EstructuraGobierno()
        {
            List<IEstructura_Gobierno> estructura = new List<IEstructura_Gobierno>();


            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/estructura_gobierno"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    estructura = JsonConvert.DeserializeObject<List<IEstructura_Gobierno>>(respApi);
                    //ViewBag.Estructura = new SelectList(estructura);
                }
                ViewBag.Estructura = new SelectList(estructura);


            }
            return View(estructura);
        }
    }
}
