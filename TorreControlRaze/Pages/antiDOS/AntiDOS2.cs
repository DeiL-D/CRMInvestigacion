using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TorreControlRaze.Pages.antiDOS
{
    public class antiDOS2
    {
        private static readonly ConcurrentDictionary<string, short> _IpAdresses = new ConcurrentDictionary<string, short>();
        private static readonly ConcurrentStack<string> _Banned = new ConcurrentStack<string>();
        private static readonly Timer _Timer = CreateTimer();
        private static readonly Timer _BannedTimer = CreateBanningTimer();

        private const int BANNED_REQUESTS = 10;
        private const int REDUCTION_INTERVAL = 1000; // 1 second
        private const int RELEASE_INTERVAL = 5 * 60 * 1000; // 5 minutes

        private readonly ILogger _logger;

        public antiDOS2(ILogger<antiDOS> logger)
        {
            _logger = logger;
        }

        public async Task OnPageLoad(HttpContext httpContext)
        {
            string ip = httpContext.Connection.RemoteIpAddress.ToString();

            if (_Banned.Contains(ip))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await httpContext.Response.WriteAsync("Access denied");
                return;
            }

            CheckIpAddress(ip);
        }

        private void CheckIpAddress(string ip)
        {
            if (!_IpAdresses.ContainsKey(ip))
            {
                _IpAdresses[ip] = 1;
            }
            else if (_IpAdresses[ip] == BANNED_REQUESTS)
            {
                _Banned.Push(ip);
                _IpAdresses.TryRemove(ip, out short _);
            }
            else
            {
                _IpAdresses[ip]++;
            }
        }

        private static Timer CreateTimer()
        {
            var timer = new Timer(REDUCTION_INTERVAL);
            timer.Elapsed += (sender, e) =>
            {
                var keys = _IpAdresses.Keys.ToList();
                foreach (string key in keys)
                {
                    if (_IpAdresses.TryGetValue(key, out var value))
                    {
                        _IpAdresses[key]--;
                        if (value == 0)
                        {
                            _IpAdresses.TryRemove(key, out short _);
                        }
                    }
                }
            };
            timer.Start();
            return timer;
        }

        private static Timer CreateBanningTimer()
        {
            var timer = new Timer(RELEASE_INTERVAL);
            timer.Elapsed += (sender, e) =>
                            if (_Banned.TryPop(out var ip))
            {
                _logger.LogInformation($"IP {ip} ha sido desbloqueada");
            }
        };
        timer.Start();
            return timer;
        }
}
}
            {