﻿using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class NormasExternasController : Controller
    {
        public async Task<IActionResult> NormasExternas()
        {
            List<INormas_Externas> normasExternas = new List<INormas_Externas>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/normas_externa"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    normasExternas = JsonConvert.DeserializeObject<List<INormas_Externas>>(respApi1);

                }
               

            }

            return View(normasExternas);
        }
    }
}