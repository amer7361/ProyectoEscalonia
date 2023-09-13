using LaEscalonia.Models;
using LaEscalonia.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.WebRequestMethods;

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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario model)
        {
            
            if (!ModelState.IsValid)
            {
                TempData["ErrorCreateUsuarios"] = "Error al crear el Usuario";
                return View(model);
            }
            return RedirectToAction("Index");
        }



        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorModifyUsuarios"] = "Error al modificar el usuario";
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
