using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ConversatoriosController : Controller
    {
        public async Task<IActionResult> Conversatorio()
        {

            List<IConversatorio> conversatorio = new List<IConversatorio>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/conversatorios"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    conversatorio = JsonConvert.DeserializeObject<List<IConversatorio>>(respApi1);

                }
                ViewBag.Conversatorio = new SelectList(conversatorio);

            }

            return View(conversatorio);

        }
    }
}
