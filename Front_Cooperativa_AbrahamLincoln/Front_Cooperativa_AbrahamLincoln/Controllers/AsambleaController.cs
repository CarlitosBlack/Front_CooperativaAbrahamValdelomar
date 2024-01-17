using Front_Cooperativa_AbrahamLincoln.Entidades;
using Front_Cooperativa_AbrahamLincoln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class AsambleaController : Controller
    {
        private readonly IConfiguration _configuration;
        public AsambleaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Asamblea(int? id)
        {
            var nombreUsuario = new Credenciales();
            var sessionData = HttpContext.Session.Get("UserSession");
            var serializedData = Encoding.UTF8.GetString(sessionData);
            nombreUsuario = JsonConvert.DeserializeObject<Credenciales>(serializedData);
            ViewBag.Nombre = nombreUsuario.NombreUsuario;

            List<IAnios_Asamblea> anios = new List<IAnios_Asamblea>();
            List<IAsambleas> asambleas = new List<IAsambleas>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                //using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/anios_asamblea"))
                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/anios_asamblea"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    anios = JsonConvert.DeserializeObject<List<IAnios_Asamblea>>(respApi1);
                    
                }
                

                if (id != null)
                {
                    using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/asambleas/" + id))
                    {
                        //obteniendo la informacion en Json (texto)
                        string respApi1 = await carga.Content.ReadAsStringAsync();
                        //se la pasamos a la lista creada arriba
                        asambleas = JsonConvert.DeserializeObject<List<IAsambleas>>(respApi1);

                    }
                }
                ViewBag.Asambleas = new SelectList(anios, "Id", "Anios", id);

            }

            return View(asambleas);

        }
    }
}
