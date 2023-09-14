using LaEscalonia.Models;
using LaEscalonia.Models.Request;
using LaEscalonia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.WebRequestMethods;

namespace LaEscalonia.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UserController(IUserService userService, IRoleService roleService)
        {
            this._userService = userService;
            _roleService = roleService;
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

        public async Task<IActionResult> Create()
        {
            ViewData["ListadoRoles"]=await _roleService.ListarRoles();
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRequest model)
        {
            
            if (!ModelState.IsValid)
            {
                TempData["ErrorCreateUsuarios"] = "Error al crear el Usuario";
                ViewData["ListadoRoles"] = await _roleService.ListarRoles();
                return View(model);
            }
            if (await _userService.VerifyUsername(model.username)) 
            {
                ModelState.AddModelError("username", "El nombre de usuario ya existe.");
                ViewData["ListadoRoles"] = await _roleService.ListarRoles();
                return View(model);
            }
            var oUser=await _userService.IngresoUsuario(model);
            if (oUser.status == "false")
            {
                TempData["ErrorCreateUsuarios"] = oUser.message;
                return View(model);
            }
            TempData["SuccessCreateUsuarios"] = oUser.message;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Modify(int id)
        {
            ViewData["ListadoRoles"] = await _roleService.ListarRoles();
            return View(await _userService.GetUser(id));
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserRequest model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ListadoRoles"] = await _roleService.ListarRoles();
                TempData["ErrorModifyUsuarios"] = "Error al modificar el usuario";
                return View(model);
            }
            var oUser=await _userService.ModificacionUsuario(model);
            if (oUser.status == "false")
            {
                ViewData["ListadoRoles"] = await _roleService.ListarRoles();
                TempData["ErrorModifyUsuarios"] = oUser.message;
                return View(model);
            }
            TempData["SuccessModifyUsuarios"] = "El usuario fue modificado";
            return RedirectToAction("Index");
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var oUser=await _userService.DeleteUser(id);
            if(oUser == null)
            {
                return Json(new { success = false });
            }
            return Json(new { success = true });
        }
    }
}
