using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class User
    {
        public User()
        {
            Announcements = new HashSet<Announcement>();
            Messages = new HashSet<Message>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
