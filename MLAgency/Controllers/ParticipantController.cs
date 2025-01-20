using Microsoft.AspNetCore.Mvc;
using MLAgency.Controllers;
using System.Collections.Generic;
using MLAgency.Models;

public class ParticipantController : Controller
{
    private readonly ParticipantService _participantService;
    private readonly EventService _eventService;

    public ParticipantController(ParticipantService participantService, EventService eventService)
    {
        _participantService = participantService;
        _eventService = eventService;
    }

    // Afficher le formulaire d'ajout de participant
    public IActionResult AddParticipant()
    {
        ViewBag.Events = _eventService.GetAllEvents(); // Récupérer tous les événements disponibles
        return View();
    }

    // Traiter l'ajout d'un participant
    [HttpPost]
    public IActionResult AddParticipant(Participant newParticipant, int eventId)
    {
        if (ModelState.IsValid)
        {
            // Vérifier si l'événement existe
            var eventExists = _eventService.GetEventById(eventId);
            if (eventExists == null)
            {
                ModelState.AddModelError("", "The selected event does not exist.");
                ViewBag.Events = _eventService.GetAllEvents();
                return View(newParticipant);
            }

            // Associer le participant à l'événement
            var participantEvent = new ParticipantEvent
            {
                Participant = newParticipant,
                EventId = eventId
            };

            // Appeler la méthode AddParticipant
            _participantService.AddParticipant(newParticipant, participantEvent);

            TempData["SuccessMessage"] = "Participant added successfully!";
            return RedirectToAction("Index");
        }

        // Recharger la liste des événements en cas d'erreur
        ViewBag.Events = _eventService.GetAllEvents();
        return View(newParticipant);
    }

    // Liste des participants

    public IActionResult Index()
    {
        var participants = _participantService.GetAllParticipantsWithEvents();
        return View(participants);
    }

    // Afficher le formulaire d'ajout
    public IActionResult Create()
    {
        return View();
    }

    // Traiter l'ajout d'un participant
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Participant newParticipant)
    {
        if (ModelState.IsValid)
        {
            _participantService.AddParticipant(newParticipant);
            TempData["SuccessMessage"] = "Participant added successfully!";
            return RedirectToAction("Index");
        }
        return View(newParticipant);
    }

    // Afficher la confirmation de suppression
    public IActionResult Delete(int id)
    {
        var participant = _participantService.GetParticipantById(id);
        if (participant == null)
        {
            return NotFound();
        }
        return View(participant);
    }
    public IActionResult Edit(int id)
    {
        var participant = _participantService.GetParticipantById(id);
        if (participant == null)
        {
            return NotFound();
        }
        return View(participant);
    }

    [HttpPost]
    public IActionResult Edit(Participant updatedParticipant)
    {
        if (ModelState.IsValid)
        {
            _participantService.UpdateParticipant(updatedParticipant);
            TempData["SuccessMessage"] = "Participant updated successfully!";
            return RedirectToAction("Index");
        }
        return View(updatedParticipant);
    }

    // Traiter la suppression
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int id)
    {
        _participantService.DeleteParticipant(id);
        TempData["SuccessMessage"] = "Participant deleted successfully!";
        return RedirectToAction("Index");
    }
}