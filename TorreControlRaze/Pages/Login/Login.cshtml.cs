
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using TorreControlRazeDAL.Model_Scaffold;


namespace TorreControlRaze.Pages.Login
{
    public class LoginModel : PageModel
    {
        public encrypt encripter = new encrypt();
        public CspharmaInformacionalContext db = new CspharmaInformacionalContext();

        [BindProperty]
        public string userId { get; set; }
        [BindProperty]
        public string contraseña { get; set; }
        public string Name => (string)TempData[nameof(Name)];
        public void OnGet([FromForm] string name)
        {
            TempData["Name"] = name;

        }
        public IActionResult OnPostEmpleado()
        {
            
            
            var userid = db.DlkCatAccEmpleados.SingleOrDefault(u => u.CodEmpleado.Equals(userId));

            var userPasswd = db.DlkCatAccEmpleados.SingleOrDefault(u => u.ClaveEmpleado.Equals(contraseña));
            var tries = 0;

            if(userid != null && userPasswd != null)
            {
                
                if (HttpContext.Session.Id == userId)
                    HttpContext.Session.Remove(userId);
                if (HttpContext.Session.GetString(userId) == null)
                {
                    HttpContext.Session.SetString("SESSION", userId);
                }
                else {
                    HttpContext.Session.Clear();
                    HttpContext.Session.SetString("SESSION", userId);
                }
               
                return RedirectToPage("../Index");
            }
            else
            {
                tries++;
                if (tries > 3)
                {
                    // Mostrar un mensaje de error si hay más de tres intentos fallidos
                    ModelState.AddModelError(string.Empty, "Ha habido demasiados intentos de conexión fallidos. Por favor inténtelo de nuevo más tarde.");
                    return RedirectToPage("../ReCaptcha");
                }
                else
                {
                    // Mostrar el formulario de inicio de sesión de nuevo si no hay más de tres intentos fallidos
                    return RedirectToPage("/Login/Login"); 
                }
                
            }
        }
    }








}

 

