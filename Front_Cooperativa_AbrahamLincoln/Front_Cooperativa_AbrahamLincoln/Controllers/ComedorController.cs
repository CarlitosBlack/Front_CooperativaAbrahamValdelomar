using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ComedorController : Controller
    {
        public async Task<IActionResult> Comedor()
        {
            List<IComedor> comedor = new List<IComedor>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/comedor"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    comedor = JsonConvert.DeserializeObject<List<IComedor>>(respApi1);

                }

            }

            return View(comedor);
        }
    }
}
