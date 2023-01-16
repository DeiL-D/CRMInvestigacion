using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TorreControlRaze.DTOs;
using TorreControlRaze.Pages.Login;
using TorreControlRazeDAL.Model_Scaffold;

namespace TorreControlRaze.Pages.Register
{
    public class RegisterModel : PageModel
    {
        public CspharmaInformacionalContext db = new CspharmaInformacionalContext();

        public encrypt encripter = new encrypt();
        [BindProperty]
        public string userId { get; set; }
        [BindProperty]
        public string contraseña { get; set; }
      
       

        public IActionResult OnPostRegister()
        {
           
            if (ModelState.IsValid)
            {

                // creamos un nuevo usuario
                var user = new DlkCatAccEmpleado(userId, contraseña);
              

                // agregamos el usuario a la base de datos
                db.DlkCatAccEmpleados.Add(user);
                db.SaveChanges();

                return RedirectToAction("SignUpSuccess");
            }
            return null;
        }
        public IActionResult SignUpSuccess()
        {
            return RedirectToPage("/index");
        }
        //Esta es una segunda opcion de validacion y registro
        /*    public IActionResult OnPost(DlkCatAccEmpleado empleado)
            {
                var dato = "";
                var userId = db.DlkCatAccEmpleados.Where(u => encripter.Encrypt12(u.CodEmpleado, "codificameesta)32@&&sdaestoymucansao$$&&23") == empleado.CodEmpleado).FirstOrDefault();
                var userPasswd = db.DlkCatAccEmpleados.Where(u => encripter.Encrypt12(u.Passwd, "codificameesta)32@&&sdaestoymucansao$$&&23") == empleado.Passwd).FirstOrDefault();
                var tries = 0;

                if (userId == null)
                {
                    db.DlkCatAccEmpleados.Add(userId);
                    db.DlkCatAccEmpleados.Add(userPasswd);
                    db.SaveChanges();
                    return RedirectToPage("/Index");
                }
                else
                {
                    dato = "Error el usuario introducido no existe";
                    return null;
                }
            }*/
    }
    }

