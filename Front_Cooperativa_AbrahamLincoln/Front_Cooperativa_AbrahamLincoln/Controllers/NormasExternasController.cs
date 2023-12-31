﻿using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class NormasExternasController : Controller
    {
        private readonly IConfiguration _configuration;
        public NormasExternasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> NormasExternas()
        {
            List<INormas_Externas> normasExternas = new List<INormas_Externas>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/normas_externa"))
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
