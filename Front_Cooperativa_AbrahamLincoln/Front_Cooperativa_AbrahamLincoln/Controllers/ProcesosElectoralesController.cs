﻿using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ProcesosElectoralesController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProcesosElectoralesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ProcesosElectorales(int? id)
        {
            List<IAnios_Procesos_Electorales> anio = new List<IAnios_Procesos_Electorales>();
            List<IProcesos_Electorale> procesosElectorales = new List<IProcesos_Electorale>();
            //string valorVariable = _configuration["URL_CONTROLLER"];

            using (var listarComponentes = new HttpClient())
            {
                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/anios_procesos_electorales"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    anio = JsonConvert.DeserializeObject<List<IAnios_Procesos_Electorales>>(respApi1);

                }

                if (id != null)
                {
                    using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/procesos_electorales/" + id))
                    {
                        //obteniendo la informacion en Json (texto)
                        string respApi1 = await carga.Content.ReadAsStringAsync();
                        //se la pasamos a la lista creada arriba
                        procesosElectorales = JsonConvert.DeserializeObject<List<IProcesos_Electorale>>(respApi1);

                    }
                }
                ViewBag.ProcesosElectorales = new SelectList(anio, "Id", "AnioProcesosElectorales", id);

            }
            return View(procesosElectorales);

        }
    }
}
