using MCOKUMUStores.Data;
using MCOKUMUStores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MCOKUMUStores.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; 

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact() => View();

        [HttpPost]
        public IActionResult Contact(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                // Save to database
                _context.ContactMessages.Add(model);
                _context.SaveChanges();

                TempData["Message"] = "Thank you for reaching out!";
                return RedirectToAction("Contact");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Subscribe(string email)
        {
            _context.Subscriptions.Add(new Subscription { Email = email });
            _context.SaveChanges();

            TempData["SubscriptionMessage"] = "You've subscribed successfully!";
            return RedirectToAction("Index");
        }
    }
}
