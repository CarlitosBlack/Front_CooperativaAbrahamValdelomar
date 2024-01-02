using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ColegioController : Controller
    {
        //ACA COMIENZA PRUEBA DE VARIABLE DE ENTORNO
        private readonly IConfiguration _configuration;
        public ColegioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //ACA TERMINA

        public async Task<IActionResult> colegio()
        {

            List<IColegio> colegio = new List<IColegio>();
            //CREAMOS VARIABLE PARA VOLVER A STRING NUESTRA VARIABLE DE ENTORNO
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/colegio"))
                //using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/colegio"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    colegio = JsonConvert.DeserializeObject<List<IColegio>>(respApi1);
                    
                }
                ViewBag.Colegio = new SelectList(colegio);

            }

            return View(colegio);

        }
    }
}
