using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ApoyoController : Controller
    {
        public async Task<IActionResult> Apoyo()
        {

            List<IApoyo> apoyo = new List<IApoyo>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/apoyo"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    apoyo = JsonConvert.DeserializeObject<List<IApoyo>>(respApi1);

                }
                ViewBag.Apoyo = new SelectList(apoyo);

            }

            return View(apoyo);

        }
    }
}
