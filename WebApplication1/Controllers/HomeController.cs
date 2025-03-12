using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<TrainingSession> sessions = new List<TrainingSession>
        {
            new TrainingSession { Id = 1, Title = "C# Basics", Date = DateTime.Today.AddDays(1), Trainer = "John Doe", Location = "Room 101" },
            new TrainingSession { Id = 2, Title = "ASP.NET MVC", Date = DateTime.Today.AddDays(3), Trainer = "Jane Smith", Location = "Room 202" },
            new TrainingSession { Id = 2, Title = "ASP.NET MVC", Date = DateTime.Today.AddDays(3), Trainer = "Jane Smith", Location = "Room 202" },
            new TrainingSession { Id = 3, Title = "Database Design", Date = DateTime.Today.AddDays(-2), Trainer = "Alice Johnson", Location = "Room 303" },
            new TrainingSession { Id = 3, Title = "Database Design", Date = DateTime.Today.AddDays(-3), Trainer = "Alice Johnson", Location = "Room 303" },
            new TrainingSession { Id = 3, Title = "Database Design", Date = DateTime.Today.AddDays(-4), Trainer = "Alice Johnson", Location = "Room 303" }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int weekOffset = 0)
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1).AddDays(weekOffset * 7);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            var weekSessions = sessions
                .Where(s => s.Date >= startOfWeek && s.Date <= endOfWeek)
                .OrderBy(s => s.Date)
                .ToList();

            ViewBag.StartOfWeek = startOfWeek;
            ViewBag.WeekOffset = weekOffset;
            return View(weekSessions);
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
