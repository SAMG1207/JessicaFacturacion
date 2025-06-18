using System.Diagnostics;
using System.Threading.Tasks;
using JessicaFacturacion.Models;
using JessicaFacturacion.Services.JessicaService;
using Microsoft.AspNetCore.Mvc;

namespace JessicaFacturacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJessicaService _jessicaService;

        public HomeController(ILogger<HomeController> logger, IJessicaService jessicaService)
        {
            _logger = logger;
            _jessicaService = jessicaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LoginJessica(ViewModels.JessicaViewModel model)
        {
            var login = await _jessicaService.ExecuteLogin(model.Email, model.Password);
            if (login)
            {
                HttpContext.Session.SetString("Jessica_Luengo_Alcibar", model.Email);
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Credenciales Incorrectas";
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
