using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InfraestructuraProyectoController : Controller
    {
        public async Task<IActionResult> InfraestructraProyecto()
        {

            List<IInfraestructura_Proyecto> infraestructura = new List<IInfraestructura_Proyecto>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/infraestructura_proyectos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    infraestructura = JsonConvert.DeserializeObject<List<IInfraestructura_Proyecto>>(respApi1);

                }
                ViewBag.InfraestructuraProyecto = new SelectList(infraestructura);

            }

            return View(infraestructura);

        }
    }
}
