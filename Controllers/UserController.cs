using LaEscalonia.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaEscalonia.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> ListarUsuarios()
        {
           var oUsers=await _userService.ListarUsuarios();
            return Json(new { data = oUsers });
        }
    }
}
