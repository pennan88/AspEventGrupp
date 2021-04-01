using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspEventGrupp.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty("Organizer")]
        public Event HostedEvents { get; set; }

        [InverseProperty("Attendess")]
        public List<Event> JoinedEvents { get; set; }
    }
}
