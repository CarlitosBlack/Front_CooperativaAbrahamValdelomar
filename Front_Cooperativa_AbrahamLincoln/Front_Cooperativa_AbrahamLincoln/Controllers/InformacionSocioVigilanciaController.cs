using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InformacionSocioVigilanciaController : Controller
    {
        public async Task<IActionResult> InformacionSocioVigilancia()
        {

            List<IInfo_Socio_Vigilancia> infoSocioVigi = new List<IInfo_Socio_Vigilancia>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/informacion_socio_vigilancia"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    infoSocioVigi = JsonConvert.DeserializeObject<List<IInfo_Socio_Vigilancia>>(respApi1);

                }
                ViewBag.InfoSocioVigilancia = new SelectList(infoSocioVigi);

            }

            return View(infoSocioVigi);

        }
    }
}
