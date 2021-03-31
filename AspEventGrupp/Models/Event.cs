using System;
using System.Collections.Generic;
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
        public DateTime Date { get; set; }
        public int SpotsLeft { get; set; }
        public List<User> Attendess { get; set; }
        public List<User> Organizer { get; set; }
    }
}
