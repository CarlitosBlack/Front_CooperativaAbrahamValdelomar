using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InformacionSocioAdministracionController : Controller
    {
        public async Task<IActionResult> InfoSocioAdministracion(int? id)
        {

            List<ICategoria_Info_Socio_Administracion> nombreCatAdmin = new List<ICategoria_Info_Socio_Administracion>();
            List<IInfo_Socio_Administracion> infoSocioAdmin = new List<IInfo_Socio_Administracion>();

            using (var listarComponentes = new HttpClient())
            {
                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/categoria_info_socio_admin"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    nombreCatAdmin = JsonConvert.DeserializeObject<List<ICategoria_Info_Socio_Administracion>>(respApi1);
                }

                if (id != null)
                {
                    using (var resp = await listarComponentes.GetAsync(
                        "https://localhost:7167/api/ListarComponentes/informacion_socio_administracion/" + id))
                    {
                        string respApi = await resp.Content.ReadAsStringAsync();
                        infoSocioAdmin = JsonConvert.
                            DeserializeObject<List<IInfo_Socio_Administracion>>(respApi);
                    }
                }
                ViewBag.InfoAdmin = new SelectList(nombreCatAdmin, "Id", "Nombre_Categoria", id);
            }

            return View(infoSocioAdmin);
        }
    }
}
