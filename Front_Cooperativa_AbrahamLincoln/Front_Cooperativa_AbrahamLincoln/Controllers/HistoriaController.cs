using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class HistoriaController : Controller
    {
        public async Task<IActionResult> Historia()
        {

            List<IHistoria> historia = new List<IHistoria>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/historia"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    historia = JsonConvert.DeserializeObject<List<IHistoria>>(respApi1);

                }
                ViewBag.Historia = new SelectList(historia);

            }


            return View(historia);
        }
    }
}
