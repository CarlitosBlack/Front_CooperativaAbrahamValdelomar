using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InformacionSocioComiteElectoralController : Controller
    {
        private readonly IConfiguration _configuration;
        public InformacionSocioComiteElectoralController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> InformacionSocioComiteElectoral(int? id)
        {
            List<ICategoriaComiteElectoral> categoria = new List<ICategoriaComiteElectoral>();
            List<IInfo_Socio_Comite_Electoral> infoSocioComiteElectoral = new List<IInfo_Socio_Comite_Electoral>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {
                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/categoria_comite_electoral"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    categoria = JsonConvert.DeserializeObject<List<ICategoriaComiteElectoral>>(respApi1);

                }

                if (id != null)
                {
                    using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/informacion_socio_comite_electoral/" + id))
                    {
                        //obteniendo la informacion en Json (texto)
                        string respApi1 = await carga.Content.ReadAsStringAsync();
                        //se la pasamos a la lista creada arriba
                        infoSocioComiteElectoral = JsonConvert.DeserializeObject<List<IInfo_Socio_Comite_Electoral>>(respApi1);

                    }

                }

                    
                ViewBag.InfoSocioComiteElectoral = new SelectList(categoria, "Id", "NombreCatComiteElectoral", id);

            }

            return View(infoSocioComiteElectoral);

        }
    }
}
