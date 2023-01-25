using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TorreControlRaze.DTOs
{
   
    public class empledoDTO : IdentityUser
    {
        
        public string CodEmpleado { get; set; } 
        public string ClaveEmpleado { get; set; }
        public  string GetUserId()
        {
            return nivel_accesos_empleados;
        }
        public int Id { get; set; }
        public string nivel_accesos_empleados { get; set; }

    }
}
