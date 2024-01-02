using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Front_Cooperativa_AbrahamLincoln.Models
{
    public class Usuario
    {
        [Required]
        public string Codigo { get; set; } = null!;
        [Required]
        public string Contrasena { get; set; } = null!;
    }
}
