using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class DirectivosController : Controller
    {
        //public async Task<IActionResult> DirectivosController()
        //{
        //    List<IDirectivos> directivos = new List<IDirectivos>();

        //    using (var listarComponentes = new HttpClient())
        //    {

        //        using (var carga_directivos = await listarComponentes.GetAsync("https://localhost:7212/api/ListarComponentes/directivos"))
        //        {
        //            //obteniendo la informacion en Json (texto)
        //            string respApi1 = await carga_directivos.Content.ReadAsStringAsync();
        //            //se la pasamos a la lista creada arriba
        //            directivos = JsonConvert.DeserializeObject<List<IDirectivos>>(respApi1);
        //            ViewBag.Estructura = new SelectList(directivos);
        //        }
        //        ViewBag.Directivos = new SelectList(directivos);

        //    }

        //    return View(directivos);
        //}

        public async Task<IActionResult> directivo(int? id) {

            List<IDirectivos> directivos = new List<IDirectivos>();
            List<ITipo_Equipo_Directivos> equipos = new List<ITipo_Equipo_Directivos>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/tipo_equipos"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    equipos = JsonConvert.DeserializeObject<List<ITipo_Equipo_Directivos>>(respApi1);
                }

                if (id != null)
                {
                    using (var carga_directivos = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/directivos/" + id))
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
