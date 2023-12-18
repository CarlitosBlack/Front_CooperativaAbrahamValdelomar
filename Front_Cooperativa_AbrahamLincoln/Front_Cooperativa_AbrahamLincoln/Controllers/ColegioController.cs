using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ColegioController : Controller
    {
        public async Task<IActionResult> colegio()
        {

            List<IColegio> colegio = new List<IColegio>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/colegio"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    colegio = JsonConvert.DeserializeObject<List<IColegio>>(respApi1);
                    
                }
                ViewBag.Colegio = new SelectList(colegio);

            }

            return View(colegio);

        }
    }
}
