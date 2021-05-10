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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public List<Event> HostedEvents { get; set; }
        public List<Event> JoinedEvents { get; set; }
    }
}
