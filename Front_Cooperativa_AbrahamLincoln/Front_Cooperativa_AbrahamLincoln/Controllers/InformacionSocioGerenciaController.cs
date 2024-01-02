using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class InformacionSocioGerenciaController : Controller
    {
        private readonly IConfiguration _configuration;
        public InformacionSocioGerenciaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> InformacionSocioGerencia(int? id)
        {

            List<ICategoria_Info_Socio_Gerencia> categoria = new List<ICategoria_Info_Socio_Gerencia>();
            List<IInfo_Socio_Gerencia> infoSocioGerencia = new List<IInfo_Socio_Gerencia>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/categoria_info_socio_generencia"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    categoria = JsonConvert.DeserializeObject<List<ICategoria_Info_Socio_Gerencia>>(respApi1);

                }

                if (id != null)
                {
                    using (var carga = await listarComponentes.GetAsync( "http://173.212.229.137:81/api/ListarComponentes/informacion_socio_gerencia/" + id))
                    {
                        //obteniendo la informacion en Json (texto)
                        string respApi1 = await carga.Content.ReadAsStringAsync();
                        //se la pasamos a la lista creada arriba
                        infoSocioGerencia = JsonConvert.DeserializeObject<List<IInfo_Socio_Gerencia>>(respApi1);

                    }
                }

                ViewBag.InfoSocioGerencia = new SelectList(categoria, "Id", "CategoriaGerencia", id);
            }

            return View(infoSocioGerencia);

        }
    }
}
