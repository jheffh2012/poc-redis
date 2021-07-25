using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using poc.Redis.WebApp.Data;
using poc.Redis.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace poc.Redis.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RedisConnection _redisConnection;
        private readonly IConfiguration _configuration;

        public HomeController(
            ILogger<HomeController> logger,
            RedisConnection redisConnection,
            IConfiguration configuration
        )
        {
            _logger = logger;
            _redisConnection = redisConnection;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.NomeAplicacao = _configuration.GetValue<string>("NomeAplicacao");
            ViewBag.ValorChave = _redisConnection.GetValueFromKey("key_name");

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
