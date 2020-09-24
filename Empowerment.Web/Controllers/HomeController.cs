using Empowerment.Web.Helpers;
using Empowerment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Empowerment.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmailSenderHelper _emailSender;
        public HomeController(IEmailSenderHelper emailSender)
        {
            _emailSender = emailSender;
        }

        // Configuracion para enviar correo

        //public async Task<IActionResult> Index()
        //{
        //    await _emailSender
        //        .SendEmailAsync("usuario@email.com", "Asunto", "Mensaje")
        //        .ConfigureAwait(false);

        //    return View();
        //}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
