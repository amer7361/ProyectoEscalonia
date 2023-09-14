using LaEscalonia.Models;
using LaEscalonia.Models.Request;
using LaEscalonia.Models.Response;

namespace LaEscalonia.Services
{
    public interface IUserService
    {
        Task<UserResponse> IngresoUsuario(UserRequest model);
        Task<UserResponse> ModificacionUsuario(UserRequest model);
        Task<Usuario> GetByID(int id);
        Task<bool> VerifyUsername(string username);
        Task<IEnumerable<UserList>> ListarUsuarios();
        Task<Usuario> DeleteUser(int id);
        Task<UserRequest> GetUser(int id);
    }
}
