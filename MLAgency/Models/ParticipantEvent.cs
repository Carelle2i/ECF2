using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MLAgency.Models;

public class ParticipantEvent
{
    public int ParticipantId { get; set; }
    public Participant Participant { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }
}
