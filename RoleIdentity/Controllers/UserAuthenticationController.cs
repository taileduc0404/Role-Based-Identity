using Microsoft.AspNetCore.Mvc;
using RoleIdentity.Models.DTO;
using RoleIdentity.Repositories.Abstract;

namespace RoleIdentity.Controllers
{
	public class UserAuthenticationController : Controller
	{
		private readonly IUserAuthenticationService _service;
        public UserAuthenticationController(IUserAuthenticationService service)
        {
            _service = service;
        }
        public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(Login login)
		{
			if(!ModelState.IsValid)
			{
				return View(login);
			}
			var result = await _service.LoginAsync(login);
			if(result.StatusCode==1)
			{
				return RedirectToAction("Display","DashBoard");
			}
		}
	}
}

