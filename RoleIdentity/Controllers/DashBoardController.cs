using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoleIdentity.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
