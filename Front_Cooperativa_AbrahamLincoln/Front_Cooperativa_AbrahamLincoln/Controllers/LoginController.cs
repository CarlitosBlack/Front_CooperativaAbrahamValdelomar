using Front_Cooperativa_AbrahamLincoln.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Front_Cooperativa_AbrahamLincoln.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        //public IActionResult Login()
        //{
        //    return View();
        //}

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            // Configura la URL base del API de acceso
            _httpClient.BaseAddress = new Uri("http://173.212.229.137:81/api/Loggin/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            //ILogin nombredeusuario;
            //using (var httpClient = new HttpClient())
            //{
            //    using (var carga = await httpClient.GetAsync("http://173.212.229.137:81/api/Loggin/Login"))
            //    {
            //        string respApi1 = await carga.Content.ReadAsStringAsync();
            //        nombredeusuario = JsonConvert.DeserializeObject<ILogin>(respApi1);
            //        //ViewData["Nombre"] = nombre;
            //    }

            //    ViewData["Nombre"] =  nombredeusuario;

            //}


            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            // Crea un objeto que contiene las credenciales
            //var credenciales = new Usuario { Nombre = ingreso, Contrasena = contrasena };
            var credenciales = new
            {
                codigo = usuario.Codigo,
                password = usuario.Contrasena
            };

            // Serializa las credenciales en formato JSON
            var jsonCredenciales = JsonConvert.SerializeObject(credenciales);

            Console.WriteLine("Contenido JSON enviado:");
            Console.WriteLine(jsonCredenciales);

            var content = new StringContent(jsonCredenciales, Encoding.UTF8, "application/json");

            

            // Realiza una solicitud HTTP POST al API de acceso para iniciar sesión
            var response = await _httpClient.PostAsync("Login", content);
            //Console.WriteLine(response.StatusCode);
            //Console.WriteLine(response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                // El inicio de sesión fue exitoso
                // Redirige al usuario a la página principal o realiza acciones necesarias
                return RedirectToAction("Index", "Consulta");
            }
            else
            {
                //var statusCode = response.StatusCode;
                // El inicio de sesión falló
                // Muestra un mensaje de error al usuario
                ModelState.AddModelError(string.Empty, "Credenciales inválidas, intenta de nuevo. codigo: statusCode");

                return View();
            }
        }

    }
}
