using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private IPEndPoint GetRemoteEndpoint()
        {
            var connection = HttpContext.Connection;
            return new IPEndPoint(connection.RemoteIpAddress, connection.RemotePort);
        }

        private string ReadBody()
        {
            byte[] bytes = new byte[(int)Request.ContentLength];
            Request.Body.ReadAsync(bytes, 0, bytes.Length).Wait();
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
