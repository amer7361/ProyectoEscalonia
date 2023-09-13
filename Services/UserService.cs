using LaEscalonia.Models;
using LaEscalonia.Models.Request;
using LaEscalonia.Models.Response;
using LaEscalonia.Repository;
namespace LaEscalonia.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<Usuario> _userRepository;
        private readonly IRepositoryAsync<Empleado> _empleadosRepository;
        public UserService(IRepositoryAsync<Usuario> userRepository,
            IRepositoryAsync<Empleado> empleadosRepository)
        {
            _userRepository = userRepository;
            _empleadosRepository = empleadosRepository;
        }

        public async Task<Usuario> DeleteUser(int id)
        {
            var user=await _userRepository.GetByID(id);
            if (user == null)
            {
                return new Usuario();
            }
            return await _userRepository.Delete(id);
        }

        public async Task<Usuario> GetByID(int id)
        {
            return await _userRepository.GetByID(id);
        }

        public async Task<UserResponse> IngresoUsuario(UserRequest model)
        {
            var oEmpleado=await _empleadosRepository.Insert(new Empleado()
            {
                nombres=model.nombres,
                apellidos=model.apellidos,
                email=model.email,
                telefono=model.telefono
            });
            var oUser=await _userRepository.Insert(new Usuario()
            {
                idEmpleado=oEmpleado.idEmpleado,
                idRol=model.idRol,
                username=model.username,
                password=model.password
            });
            return new UserResponse()
            {
                status="true",
                message="Usuario creado correctamente",
                user=model
            };
        }

        public async Task<IEnumerable<UserList>> ListarUsuarios()
        {
            var users=await _userRepository.GetAllWithInlcudes(u=>u.idEmpleadoNavigation,
                               u=>u.idRolNavigation);
            return users.Select(x => new UserList()
            {
                idUsuario=x.idUsuario,
                nombres=x.idEmpleadoNavigation.nombres,
                apellidos=x.idEmpleadoNavigation.apellidos,
                email=x.idEmpleadoNavigation.email,
                telefono=x.idEmpleadoNavigation.telefono,
                username=x.username,
                rol=x.idRolNavigation.rol
            });
        }

        public async Task<UserResponse> ModificacionUsuario(UserRequest model)
        {
            var user=await _userRepository.GetWithInlcudes(u=>u.idUsuario==model.idUsuario,
                u=>u.idEmpleadoNavigation);
            if (user == null)
            {
                return new UserResponse()
                {
                    status = "false",
                    message = "Usuario No Exitente",
                    user = model
                };
            }
            await _empleadosRepository.Update(new Empleado()
            {
                nombres = model.nombres,
                apellidos = model.apellidos,
                email = model.email,
                telefono = model.telefono,
                idEmpleado=user.idEmpleadoNavigation.idEmpleado
            });
            await _userRepository.Update(new Usuario()
            {
                idEmpleado = user.idEmpleadoNavigation.idEmpleado,
                idRol = model.idRol,
                username = model.username,
                password = model.password
            });
            return new UserResponse()
            {
                status = "true",
                message = "Usuario creado correctamente",
                user = model
            };
        }
    }
}
