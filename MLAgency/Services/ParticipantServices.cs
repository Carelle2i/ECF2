using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MLAgency.Models;


public class ParticipantService
{
    private readonly AppDbContext _context;

    public ParticipantService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Authentifie un participant par email et mot de passe.
    /// </summary>
    public Participant? Authenticate(string email, string password)
    {
        return _context.Participants
            .FirstOrDefault(p => p.Email == email && p.Password == password);
    }

    /// <summary>
    /// Récupère un participant par ID.
    /// </summary>
    public Participant? GetParticipantById(int id)
    {
        return _context.Participants
            .Include(p => p.ParticipantEvents)
            .ThenInclude(pe => pe.Event)
            .FirstOrDefault(p => p.Id == id);
    }

    /// <summary>
    /// Récupère tous les participants avec leurs événements associés.
    /// </summary>
    public List<Participant> GetAllParticipantsWithEvents()
    {
        return _context.Participants
            .Include(p => p.ParticipantEvents)
            .ThenInclude(pe => pe.Event)
            .ToList();
    }

    /// <summary>
    /// Ajoute un participant et l'associe à un événement.
    /// </summary>
    public void AddParticipant(Participant participant, ParticipantEvent? participantEvent = null)
    {
        // Ajouter le participant
        _context.Participants.Add(participant);

        // Ajouter la relation avec un événement, si fournie
        if (participantEvent != null)
        {
            _context.ParticipantEvents.Add(participantEvent);
        }

        // Sauvegarder les changements
        _context.SaveChanges();
    }

    /// <summary>
    /// Met à jour les informations d'un participant existant.
    /// </summary>
    public void UpdateParticipant(Participant updatedParticipant)
    {
        var existingParticipant = _context.Participants.Find(updatedParticipant.Id);

        if (existingParticipant != null)
        {
            // Mettre à jour les champs nécessaires
            existingParticipant.FullName = updatedParticipant.FullName;
            existingParticipant.Email = updatedParticipant.Email;
            existingParticipant.Password = updatedParticipant.Password;

            // Sauvegarder les modifications
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Supprime un participant par ID.
    /// </summary>
    public void DeleteParticipant(int id)
    {
        var participant = _context.Participants
            .Include(p => p.ParticipantEvents)
            .FirstOrDefault(p => p.Id == id);

        if (participant != null)
        {
            // Supprimer les relations avec les événements
            _context.ParticipantEvents.RemoveRange(participant.ParticipantEvents);

            // Supprimer le participant
            _context.Participants.Remove(participant);

            // Sauvegarder les changements
            _context.SaveChanges();
        }
    }
}
