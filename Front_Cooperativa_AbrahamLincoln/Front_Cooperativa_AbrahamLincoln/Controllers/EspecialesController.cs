using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class EspecialesController : Controller
    {
        public async Task<IActionResult> Especiales()
        {

            List<IEspeciales> especiales = new List<IEspeciales>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/especiales"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    especiales = JsonConvert.DeserializeObject<List<IEspeciales>>(respApi1);

                }
                ViewBag.Especiales = new SelectList(especiales);

            }

            return View(especiales);

        }
    }
}
