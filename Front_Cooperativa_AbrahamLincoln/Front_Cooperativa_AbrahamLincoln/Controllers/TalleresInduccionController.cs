using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class TalleresInduccionController : Controller
    {
        public async Task<IActionResult> TalleresInduccion()
        {

            List<ITalleres_Induccion> talleresInduccion = new List<ITalleres_Induccion>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/talleres_de_induccion"))
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
