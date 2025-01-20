using System.Collections.Generic;
using System.Linq;
using MLAgency.Models;

public class EventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    // Récupérer tous les événements
    public List<Event> GetAllEvents()
    {
        return _context.Events.ToList();
    }

    // Récupérer un événement par son ID
    public Event? GetEventById(int id)
    {
        return _context.Events.FirstOrDefault(e => e.Id == id);
    }

    // Ajouter un nouvel événement
    public void AddEvent(Event newEvent)
    {
        _context.Events.Add(newEvent);
        _context.SaveChanges();
    }

    // Mettre à jour un événement existant
    public void UpdateEvent(Event updatedEvent)
    {
        _context.Events.Update(updatedEvent);
        _context.SaveChanges();
    }

    // Supprimer un événement
    public void DeleteEvent(int id)
    {
        var eventToDelete = _context.Events.Find(id);
        if (eventToDelete != null)
        {
            _context.Events.Remove(eventToDelete);
            _context.SaveChanges();
        }
    }
}