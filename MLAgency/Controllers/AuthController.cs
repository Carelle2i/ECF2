using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    private readonly ParticipantService _participantService;

    public AuthController(ParticipantService participantService)
    {
        _participantService = participantService;
    }

    // Afficher le formulaire de connexion
    public IActionResult Login()
    {
        return View();
    }

    // Traiter la connexion
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var participant = _participantService.Authenticate(email, password);
        if (participant != null)
        {
            HttpContext.Session.SetInt32("ParticipantId", participant.Id);
            HttpContext.Session.SetString("ParticipantName", participant.FullName);
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid email or password.");
        return View();
    }

    // Déconnexion
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
