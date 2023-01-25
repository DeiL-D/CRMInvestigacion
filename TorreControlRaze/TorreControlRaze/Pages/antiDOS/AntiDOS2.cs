using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TorreControlRaze.Pages.antiDOS
{
    public class antiDDOS
    {
        private static readonly ConcurrentDictionary<string, int> _IpAdresses = new ConcurrentDictionary<string, int>();
        private static readonly ConcurrentDictionary<string, DateTime> _Banned = new ConcurrentDictionary<string, DateTime>();
        private const int BANNED_REQUESTS = 10;
        private const int BAN_DURATION = 5; // in minutes
        private readonly ILogger _logger;

        public antiDDOS(ILogger<antiDDOS> logger)
        {
            _logger = logger;
        }

        public async Task OnPageLoad(HttpContext httpContext)
        {
            string ip = httpContext.Connection.RemoteIpAddress.ToString();

            if (_Banned.ContainsKey(ip) && _Banned[ip] > DateTime.UtcNow)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await httpContext.Response.WriteAsync("Access denied");
                return;
            }

            CheckIpAddress(ip);
        }

        private void CheckIpAddress(string ip)
        {
             ip = "Ip.ejemplo.para.otrIp"; //Input de ejemplo, sustituir por ip recibida en parametros

            //Poniendo los readers primero, damos por hecho que los ficheros existen en el directorio por defecto
            StreamReader bannedReader = new StreamReader("BANNED_IPs.txt");
            StreamReader friendlyReader = new StreamReader("FRIENDLY_IPs.txt");

            //Guardamos todos los registros en listas
            List<string> bannedList = bannedReader.ReadToEnd().Split(';').ToList<String>();
            List<string> friendlyList = friendlyReader.ReadToEnd().Split(';').ToList<String>();

            String bannedIp = bannedList.Where(x => x == ip).FirstOrDefault();
            if (bannedIp != null && bannedIp == ip)
                Console.WriteLine("Test de ban permanente");
            //Aqui es donde iría un redirect al login o a una pantalla de error

            //Cerramos los readers para evitar problemas con los writers
            bannedReader.Close();
            friendlyReader.Close();

            StreamWriter friendlyIps = File.AppendText("FRIENDLY_IPs.txt");
            friendlyIps.Write(ip + ';');
            friendlyIps.Close();

            StreamWriter bannedIps = File.AppendText("BANNED_IPS.txt");

            /*Leemos la lista de ips amistosas, habría que buscar un modo de hacer que cada x tiempo,
             * (por ejemplo 10 minutos) borre todos los registros,
             * ya que por el contrario, mantendría baneadas ciertas ips de forma infinita
             */

            List<String> toBan = friendlyList.Where(x => x == ip).ToList();

            if (toBan.Count >= 10)
                bannedIps.Write(toBan[0] + ";");

            bannedIps.Close();
        }
    }
}