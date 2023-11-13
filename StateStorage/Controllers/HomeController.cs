using Microsoft.AspNetCore.Mvc;
using StateStorage.Models;
using System.Diagnostics;

namespace StateStorage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DataModel model)
        {
            CookieOptions ending = new CookieOptions();
            ending.Expires = model.End;
            Response.Cookies.Append("Data", model.Adress, ending);
            return View();
        }

        public IActionResult Privacy()

        {
            if (Request.Cookies.TryGetValue("Data", out string value))
            {
                return View((object)value);

            }
            return View((object)"Absent");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}