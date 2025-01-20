using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MLAgency.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FullName { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Le mot de passe doit avoir au moins 8 caractères.")]
        public string Password { get; set; }

        public ICollection<ParticipantEvent> ParticipantEvents { get; set; } = new List<ParticipantEvent>();
    }
}
