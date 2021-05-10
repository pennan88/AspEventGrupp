using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspEventGrupp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Adress { get; set; }
        public string Genre { get; set; }
        public string EventImage { get; set; }
        public DateTime Date { get; set; }
        public int SpotsLeft { get; set; }

        [InverseProperty("HostedEvents")]
        public User Organizer { get; set; }

        [InverseProperty("JoinedEvents")]
        public List<User> Attendees { get; set; }
    }
}
