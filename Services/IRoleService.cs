using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaEscalonia.Services
{
    public interface IRoleService
    {
        Task<List<SelectListItem>> ListarRoles();
    }
}
