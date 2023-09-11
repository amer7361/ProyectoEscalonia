using LaEscalonia.Models.Request;

namespace LaEscalonia.Models.Response
{
    public class UserResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public UserRequest user { get; set; }
    }
    public class UserList
    {
        public int idUsuario { get; set; }
        public string username { get; set; } 

        public string nombres { get; set; } 

        public string apellidos { get; set; } 

        public string telefono { get; set; } 

        public string email { get; set; }
        public string rol { get; set; }

    }
}
