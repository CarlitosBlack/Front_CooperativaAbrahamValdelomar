using Front_Cooperativa_AbrahamLincoln.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Front_Cooperativa_AbrahamLincoln.Servicios;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Plugins;
using System.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            // Aquí configura la URL base de la API remota
            //_httpClient.BaseAddress = new Uri("https://localhost:7167/api/");
            _httpClient.BaseAddress = new Uri("http://173.212.229.137:81/api/");
        }

        [HttpGet]
        public IActionResult Login()
        {

            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Consulta");
            }
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login( LoginViewModel model)
        //{
        //    try
        //    {
        //        var credenciales = new
        //        {
        //            codigo = model.Codigo,
        //            password = model.Password
        //        };

        //        //Convierte el objeto de Usuario a un JSON para enviar en la solicitud
        //       var jsonCredenciales = JsonConvert.SerializeObject(credenciales);
        //        var content = new StringContent(jsonCredenciales, Encoding.UTF8, "application/json");

        //        //Realiza la solicitud POST al endpoint de inicio de sesión en la API remota
        //        var response = await _httpClient.PostAsync("Loggin/Login", content);
        //        //Console.WriteLine(response.StatusCode);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadFromJsonAsync<Credenciales>();
        //            var serializedResult = JsonConvert.SerializeObject(result);
        //            byte[] byteResult = Encoding.UTF8.GetBytes(serializedResult);
        //            HttpContext.Session.Set("UserSession", byteResult);

        //            return RedirectToAction("Index", "Consulta");
        //        }
        //        else
        //        {
        //            TempData["Status"] = "error";
        //            return View();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al procesar la solicitud: {ex.Message}");
        //    }
        //}   

        [HttpPost]
        public  IActionResult Login( /*JObject response*/ [FromBody] Credenciales respuestaString)
        {
            Console.WriteLine(respuestaString);
            //dynamic datosDinamicos = response;

            //var result = respuestaString.Content.ReadFromJsonAsync<Credenciales>();
            //var serializedResult = JsonConvert.SerializeObject(respuestaString);
            //byte[] byteResult = Encoding.UTF8.GetBytes(serializedResult);
            //HttpContext.Session.Set("UserSession", byteResult);
            //HttpContext.Session.Set("UserSession", respuestaString);

            try
            {
                var json = JsonConvert.SerializeObject(respuestaString);
                byte[] bytesCredenciales = Encoding.UTF8.GetBytes(json);
                HttpContext.Session.Set("UserSession", bytesCredenciales);
                return RedirectToAction("Index", "Consulta");

            }
            catch (Exception ex)
            {
                // Loggear error  
                return StatusCode(500, $"Error serializando credenciales : {ex.Message}");
            }

            //return View();
            
        }

    }
}
