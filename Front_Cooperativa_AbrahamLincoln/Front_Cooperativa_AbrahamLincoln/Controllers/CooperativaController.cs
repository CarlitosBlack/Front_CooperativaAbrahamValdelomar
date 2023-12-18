﻿using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class CooperativaController : Controller
    {
        public async Task<IActionResult> cooperativa()
        {

            List<ICooperativa> cooperativa = new List<ICooperativa>();

            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/cooperativa"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    cooperativa = JsonConvert.DeserializeObject<List<ICooperativa>>(respApi1);
                    
                }
                ViewBag.Cooperativa = new SelectList(cooperativa);

            }

            return View(cooperativa);
        
        }
    }
}
