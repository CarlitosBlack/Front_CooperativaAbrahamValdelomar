using Front_Cooperativa_AbrahamLincoln.Models;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net.Http;
using System.Threading.Tasks;
namespace Front_Cooperativa_AbrahamLincoln.Servicios
{
    public class LoginService
    {
        //private readonly HttpClient _httpClient;

        //public LoginService(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //Credenciales user = new Credenciales();


        //public async Task<string> GetUserNameAsync()
        //{
        //    var response = await _httpClient.GetAsync("https://localhost:7167/api/Loggin/Login");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var userData = await response.Content.ReadAsStringAsync(); // Clase UserData que representa la estructura de la respuesta
        //        user = JsonConvert.DeserializeObject<Credenciales>(userData);
        //        return user.NombreUsuario; // Nombre de usuario obtenido de la respuesta de la API
        //    }
        //    else
        //    {
        //        // Manejo de errores si la solicitud no tiene éxito
        //        return null;
        //    }
        //}


    }
}
