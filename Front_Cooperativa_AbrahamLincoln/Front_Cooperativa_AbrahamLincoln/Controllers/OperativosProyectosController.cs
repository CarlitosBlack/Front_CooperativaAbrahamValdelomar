using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class OperativosProyectosController : Controller
    {
        public async Task<IActionResult> OperativosProyectos()
        {

            List<IOperativos_Proyecto> operativos = new List<IOperativos_Proyecto>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/operativos_proyectos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    operativos = JsonConvert.DeserializeObject<List<IOperativos_Proyecto>>(respApi1);

                }
                ViewBag.OperativosProyectos = new SelectList(operativos);

            }

            return View(operativos);

        }
    }
}
