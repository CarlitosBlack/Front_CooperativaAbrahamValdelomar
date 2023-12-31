﻿using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ComedorController : Controller
    {
        private readonly IConfiguration _configuration;
        public ComedorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Comedor()
        {
            List<IComedor> comedor = new List<IComedor>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/comedor"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    comedor = JsonConvert.DeserializeObject<List<IComedor>>(respApi1);

                }

            }

            return View(comedor);
        }
    }
}
