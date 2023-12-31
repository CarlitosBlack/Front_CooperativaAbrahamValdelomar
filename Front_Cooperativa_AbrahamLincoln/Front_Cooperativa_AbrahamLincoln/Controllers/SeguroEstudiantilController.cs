﻿using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class SeguroEstudiantilController : Controller
    {
        private readonly IConfiguration _configuration;
        public SeguroEstudiantilController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> SeguroEstudiantil()
        {

            List<ISeguro_Estudiantil> seguro = new List<ISeguro_Estudiantil>();
            //string valorVariable = _configuration["URL_CONTROLLER"];
            using (var listarComponentes = new HttpClient())
            {

                using (var carga = await listarComponentes.GetAsync("http://173.212.229.137:81/api/ListarComponentes/seguro_estudiantil"))
                {
                    //obteniendo la informacion en Json (texto)
                    string respApi1 = await carga.Content.ReadAsStringAsync();
                    //se la pasamos a la lista creada arriba
                    seguro = JsonConvert.DeserializeObject<List<ISeguro_Estudiantil>>(respApi1);

                }
                ViewBag.Historia = new SelectList(seguro);

            }

            return View(seguro);
        }
    }
}
