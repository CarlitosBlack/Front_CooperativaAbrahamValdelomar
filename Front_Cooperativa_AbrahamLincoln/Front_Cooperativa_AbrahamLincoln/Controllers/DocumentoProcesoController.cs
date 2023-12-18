using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class DocumentoProcesoController : Controller
    {
        public async Task<IActionResult> DocumentoProceso(int? id)
        {
            List<IDocumento_Proceso> documentos = new List<IDocumento_Proceso>();
            List<IProceso> procesos = new List<IProceso>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/procesos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    procesos = JsonConvert.DeserializeObject<List<IProceso>>(respApi1);

                }

                if (id != null)
                {
                    using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/documentos_procesos/" + id))
                    {
                        //obteniendo la informacion en Json (texto)
                        string respApi1 = await carga.Content.ReadAsStringAsync();
                        //se la pasamos a la lista creada arriba
                        documentos = JsonConvert.DeserializeObject<List<IDocumento_Proceso>>(respApi1);

                    }

                }

                ViewBag.Procesos = new SelectList(procesos, "Id", "Anio_Gerencia", id);

            }

            return View(documentos);

        }
    }
}
