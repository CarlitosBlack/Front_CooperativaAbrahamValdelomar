using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ConversatoriosController : Controller
    {
        private readonly IConfiguration _configuration;
        public ConversatoriosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Conversatorio()
        {

            List<IConversatorio> conversatorio = new List<IConversatorio>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/conversatorios"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    conversatorio = JsonConvert.DeserializeObject<List<IConversatorio>>(respApi1);

                }
                ViewBag.Conversatorio = new SelectList(conversatorio);

            }

            return View(conversatorio);

        }
    }
}
