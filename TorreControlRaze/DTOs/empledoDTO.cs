using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TorreControlRaze.DTOs
{
   
    public class empledoDTO
    {
        
        public string CodEmpleado { get; set; } 
        public string Passwd { get; set; } 
       
        public int Id { get; set; }
    }
}
