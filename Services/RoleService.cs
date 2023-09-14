using LaEscalonia.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Utilities_Net_6_MVC;

namespace LaEscalonia.Services
{
    public class RoleService : IRoleService
    {
        private readonly EscaloniaContext _context;
        public RoleService(EscaloniaContext context)
        {
            _context = context;
        }
        public async Task<List<SelectListItem>> ListarRoles()
        {
            var roles=await _context.Roles.ToListAsync();
            return SelectListItemHelper.ToSelectListItems(roles, r=>r.rol,r=>r.idRol.ToString());
        }
    }
}
