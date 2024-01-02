using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class DirectivosController : Controller
    {
        private readonly IConfiguration _configuration;
        public DirectivosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> directivo(int? id) {

            List<IDirectivos> directivos = new List<IDirectivos>();
            List<ITipo_Equipo_Directivos> equipos = new List<ITipo_Equipo_Directivos>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                //using (var carga = await listarComponentes.GetAsync(valorVariable + "/api/ListarComponentes/tipo_equipos"))
                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/tipo_equipos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    equipos = JsonConvert.DeserializeObject<List<ITipo_Equipo_Directivos>>(respApi1);
                }

                if (id != null)
                {
                    using (var carga_directivos = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/directivos/" + id))
                    {
                        //obteniendo la informacion en Json (texto)
                        string respApi1 = await carga_directivos.Content.ReadAsStringAsync();
                        //se la pasamos a la lista creada arriba
                        directivos = JsonConvert.DeserializeObject<List<IDirectivos>>(respApi1);

                    }
                }

                ViewBag.Directivos = new SelectList(equipos, "Id", "Nombre_Tipo_Equipo", id);
                
            }

            return View(directivos); }

    }


}
