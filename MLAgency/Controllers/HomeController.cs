using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MLAgency.Models;

namespace MLAgency.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Page d'accueil
    public IActionResult Index()
    {
        return View();
    }

    // Page de confidentialité (Privacy Policy)
    public IActionResult Privacy()
    {
        return View();
    }

    // Page de contact
    public IActionResult Contact()
    {
        return View();
    }

    // Traitement du formulaire de contact
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SendMessage(string name, string phone, string email, string eventDetails)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
        {
            ModelState.AddModelError(string.Empty, "Name and Email are required.");
            return View("Contact");
        }

        ViewBag.Name = name;
        ViewBag.Phone = phone;
        ViewBag.Email = email;
        ViewBag.EventDetails = eventDetails;

        return View("MessageSent");
    }

    // Gestion des erreurs
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

