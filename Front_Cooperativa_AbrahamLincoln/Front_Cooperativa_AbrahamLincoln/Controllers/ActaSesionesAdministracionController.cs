using Front_Cooperativa_AbrahamLincoln.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class ActaSesionesAdministracionController : Controller
    {
        public async Task<IActionResult> Acta_sesiones_administracion()
        {

            List<IAnios_Actas> aniosActas = new List<IAnios_Actas>();
            List<IActas_Sesiones_Administracion> actasSesionesAdministracion = new List<IActas_Sesiones_Administracion>();

            //using (var listarComponentes = new HttpClient())
            //{

            //    //using (var carga = await listarComponentes.GetAsync("https://localhost:7167/api/ListarComponentes/anios_actas"))
            //    //{
            //    //    //obteniendo la informacion en Json (texto)
            //    //    string respApi1 = await carga.Content.ReadAsStringAsync();
            //    //    //se la pasamos a la lista creada arriba
            //    //    aniosActas = JsonConvert.DeserializeObject<List<IAnios_Actas>>(respApi1);
                    
            //    //}

            //    //if (id != null)
            //    //{
            //        //using (var resp = await listarComponentes.GetAsync(
            //        //    "https://localhost:7167/api/ListarComponentes/actas_sesiones_administracion/" + id))
            //        //{
            //        //    string respApi = await resp.Content.ReadAsStringAsync();
            //        //    actasSesionesAdministracion = JsonConvert.
            //        //        DeserializeObject<List<IActas_Sesiones_Administracion>>(respApi);
            //        //}

            //    //}

            //    //ViewBag.ActaSesionesAdmin = new SelectList(aniosActas, "Id", "Anios", id);

            //}

            //var id = 1; // Reemplaza esto con el ID que necesitas

            //using (var httpClient = new HttpClient())
            //{
            //    try
            //    {
            //        var response = await httpClient.GetAsync($"https://localhost:7167/api/ListarComponentes/anios_actas");

            //        if (response.IsSuccessStatusCode)
            //        {
            //            var content = await response.Content.ReadAsStringAsync();
            //            Console.WriteLine($"Respuesta: {content}");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error: {ex.Message}");
            //    }
            //}


            return View();

        }
    }
}
