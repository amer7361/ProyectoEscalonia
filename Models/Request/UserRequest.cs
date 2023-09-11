namespace LaEscalonia.Models.Request
{
    public class UserRequest
    {
        public int idUsuario { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public int idRol { get; set; }
        public string nombres { get; set; } 

        public string apellidos { get; set; } 

        public string telefono { get; set; }

        public string email { get; set; } 
    }
}
