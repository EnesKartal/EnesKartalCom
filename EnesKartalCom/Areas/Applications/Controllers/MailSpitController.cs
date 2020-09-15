using Microsoft.AspNetCore.Mvc;

namespace EnesKartalCom.Areas.Applications.Controllers
{
    public class MailSpitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewSpit()
        {
            return View();
        }
        public IActionResult CreateMailConfig()
        {
            return View();
        }
        public IActionResult EditMailConfig(int id)
        {
            return View();
        }
    }
}