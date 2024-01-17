using Front_Cooperativa_AbrahamLincoln.Entidades;
using Front_Cooperativa_AbrahamLincoln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class DocumentoProcesoController : Controller
    {
        private readonly IConfiguration _configuration;
        public DocumentoProcesoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> DocumentoProceso(int? id)
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IDocumento_Proceso> documentos = new List<IDocumento_Proceso>();
            List<IProceso> procesos = new List<IProceso>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/procesos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    procesos = JsonConvert.DeserializeObject<List<IProceso>>(respApi1);

                }

                if (id != null)
                {
                    using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/documentos_procesos/" + id))
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
