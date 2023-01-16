using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TorreControlRaze.Pages.Login;
using TorreControlRazeDAL.Model_Scaffold;

namespace TorreControlRaze.Pages
{
    [Authorize(Roles = "admin,editor")]
    public class IndexModel : PageModel
    {
        private readonly TorreControlRazeDAL.Model_Scaffold.CspharmaInformacionalContext _context;
       
        public IndexModel(TorreControlRazeDAL.Model_Scaffold.CspharmaInformacionalContext context)
        {
            _context = context;
        }
        await _userManager.AddToRoleAsync(user, "roleName");
        public IList<TdcTchEstadoPedido> TdcTchEstadoPedido { get;set; } = default!;

        public string Name => (string)TempData[nameof(Name)];
        public async Task OnGet([FromForm] string name)
        {
            TempData["Name"] = "sdasdasd"+ HttpContext.Session.GetString("SESSION") +" a ver";
            TempData["apellido"] = " "+HttpContext.Session.Get("SESSION");
            if (_context.TdcTchEstadoPedidos != null)
            {
                TdcTchEstadoPedido = await _context.TdcTchEstadoPedidos
                .Include(t => t.CodEstadoDevolucionNavigation)
                .Include(t => t.CodEstadoEnvioNavigation)
                .Include(t => t.CodLineaNavigation).ToListAsync();
            }
           
        }
        public IActionResult OnPostexpirado()
        {
            return RedirectToPage("/Login/Login");
        }
        
    }
}
