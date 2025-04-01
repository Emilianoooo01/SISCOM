using Microsoft.AspNetCore.Mvc;
using SISCOM.Models;

namespace CISCOM.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            // Generar el CAPTCHA y enviarlo a la vista
            CaptchaModel cap = new CaptchaModel();
            ViewBag.Mensaje = cap.GenerarCaptcha();
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel usuDatos, string CaptchaGet)
        {
            // Validar usuario y contraseña
            if (usuDatos.Usuario != "Deiv" || usuDatos.Contrasea != "1234")
            {
                ViewBag.Error = "Usuario o contraseña incorrecto";
            }
            // Validar Captcha comparándolo con el campo oculto
            else if (usuDatos.Captcha != CaptchaGet)
            {
                ViewBag.Error = "Validar Captcha";
            }
            else
            {
                // Si todo es correcto, redirigir al home
                return RedirectToAction("Index", "Home");
            }

            // Si hubo error, generar un nuevo CAPTCHA para mostrarlo en la vista
            CaptchaModel cap = new CaptchaModel();
            ViewBag.Mensaje = cap.GenerarCaptcha();

            return View();
        }
    }
}