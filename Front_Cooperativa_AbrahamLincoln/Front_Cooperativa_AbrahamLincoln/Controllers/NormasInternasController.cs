using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class NormasInternasController : Controller
    {
        public async Task<IActionResult> NormasInternas()
        {
            List<INormas_Internas> normasInternas = new List<INormas_Internas>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/normas_internas"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    normasInternas = JsonConvert.DeserializeObject<List<INormas_Internas>>(respApi1);

                }
               

            }

            return View(normasInternas);
        }
    }
}
