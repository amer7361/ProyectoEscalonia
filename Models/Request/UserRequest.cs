using System.ComponentModel.DataAnnotations;

namespace LaEscalonia.Models.Request
{
    public class UserRequest
    {
        public int idUsuario { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Password")]

        public string password { get; set; }
        [Display(Name = "Rol")]

        public int idRol { get; set; }
        [Display(Name = "Nombres")]
        public string nombres { get; set; } 
        [Display(Name = "Apellidos")]

        public string apellidos { get; set; } 
        [Display(Name = "Telefono")]

        public string telefono { get; set; }
        [Display(Name = "Email")]

        public string email { get; set; } 
    }
}
