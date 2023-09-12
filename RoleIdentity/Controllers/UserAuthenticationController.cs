using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleIdentity.Models.DTO;
using RoleIdentity.Repositories.Abstract;

namespace RoleIdentity.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;
        private INotyfService _notyfService { get; }
        public UserAuthenticationController(IUserAuthenticationService service, INotyfService notyfService)
        {
            this._service = service;
            this._notyfService = notyfService;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            registration.Role = "User";
            var result = await _service.RegistrationAsync(registration);
            TempData["msg"] = result.Message;

            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var result = await _service.LoginAsync(login);
            if (result.StatusCode == 1)
            {
                _notyfService.Success("Logged In Successfully!");
                return RedirectToAction("Display", "DashBoard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            _notyfService.Success("Logged Out Successfully!");
            return RedirectToAction(nameof(Login));
        }


        //public async Task<IActionResult> Reg()
        //{
        //    var registration = new Registration()
        //    {
        //        Username = "Admin",
        //        Name = "Duc Tai",
        //        Email = "taileduc0404@gmail.com",
        //        Password = "Tai@1111"
        //    };
        //    registration.Role = "User";
        //    var result = await _service.RegistrationAsync(registration);
        //    return Ok(result);
        //}



    }
}

