using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Front_Cooperativa_AbrahamLincoln.Models
{
    public class Credenciales
    {
        //[Required]
        public string? Mensaje { get; set; }
        public string? NombreUsuario { get; set; }
        //[Required]
        //public string Contrasena { get; set; } = null!;
    }
}
