using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class PabellonDiplomaController : Controller
    {
        private readonly IConfiguration _configuration;
        public PabellonDiplomaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> PabellonDiploma()
        {
            List<IPabellon_Diploma> pabellon = new List<IPabellon_Diploma>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/pabellon_diploma"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    pabellon = JsonConvert.DeserializeObject<List<IPabellon_Diploma>>(respApi1);

                }

            }

            return View(pabellon);
        }
    }
}
