using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ReportesFinancierosController : Controller
    {
        private readonly IConfiguration _configuration;
        public ReportesFinancierosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ReportesFinancieros(int? id)
        {

            List<ICategoria_Reporte_Financiero> nombreCatRep = new List<ICategoria_Reporte_Financiero>();
            List<IReportes_Financieros> reportes = new List<IReportes_Financieros>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {
                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/categoria_reporte_financiero"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    nombreCatRep = JsonConvert.DeserializeObject<List<ICategoria_Reporte_Financiero>>(respApi1);
                }

                if (id != null)
                {
                    using (var resp = await listarComponentes.GetAsync(
                         "http://173.212.229.137:81/api/ListarComponentes/reportes_financieros/" + id))
                    {
                        string respApi = await resp.Content.ReadAsStringAsync();
                        reportes = JsonConvert.
                            DeserializeObject<List<IReportes_Financieros>>(respApi);
                    }
                }
                ViewBag.ReporteFinanciero = new SelectList(nombreCatRep, "Id", "NombreCategoria", id);
            }

            return View(reportes);

        }
    }
}
