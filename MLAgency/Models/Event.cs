using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MLAgency.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required] [DataType(DataType.Date)] public DateTime Date { get; set; }

        [Required] [StringLength(200)] public string Location { get; set; } = string.Empty;

        public ICollection<ParticipantEvent> ParticipantEvents { get; set; } = new List<ParticipantEvent>();
    }
}
