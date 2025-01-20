using Microsoft.AspNetCore.Mvc;
namespace MLAgency.Models;
using System.Collections.Generic;


public class EventController : Controller
{
    private readonly EventService _eventService;

    public EventController(EventService eventService)
    {
        _eventService = eventService;
    }

    // Afficher tous les événements
    public IActionResult Index()
    {
        var events = _eventService.GetAllEvents();
        return View(events);
    }

    // Afficher le formulaire de création d'un événement
    public IActionResult CreateEvent()
    {
        return View(new Event()); // Retourner une vue vide pour la création
    }

    // Créer un événement
    [HttpPost]
    public IActionResult CreateEvent(Event newEvent)
    {
        if (ModelState.IsValid)
        {
            _eventService.AddEvent(newEvent);  // Ajoute l'événement dans la base de données
            TempData["SuccessMessage"] = "Event created successfully!";
            return RedirectToAction("Index");  // Redirige vers la liste des événements
        }

        return View(newEvent); // Retourne à la vue avec les erreurs si le modèle est invalide
    }

    // Afficher le formulaire d'édition d'un événement
    public IActionResult Edit(int id)
    {
        var eventToEdit = _eventService.GetEventById(id);
        if (eventToEdit == null)
        {
            TempData["ErrorMessage"] = "Event not found.";
            return RedirectToAction("Index");
        }

        return View(eventToEdit);
    }

    // Modifier un événement
    [HttpPost]
    public IActionResult Edit(Event updatedEvent)
    {
        if (ModelState.IsValid)
        {
            _eventService.UpdateEvent(updatedEvent);
            TempData["SuccessMessage"] = "Event updated successfully!";
            return RedirectToAction("Index");
        }

        return View(updatedEvent);
    }

    // Supprimer un événement
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var eventToDelete = _eventService.GetEventById(id);
        if (eventToDelete == null)
        {
            TempData["ErrorMessage"] = "Event not found.";
            return RedirectToAction("Index");
        }

        _eventService.DeleteEvent(id);
        TempData["SuccessMessage"] = "Event deleted successfully!";
        return RedirectToAction("Index");
    }
}
