using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class Message
    {
        public int IdMessage { get; set; }
        public int IdAnnouncement { get; set; }
        public int IdUser { get; set; }
        public string Message1 { get; set; }
        public bool FromUser { get; set; }
        public DateTime Date { get; set; }

        public virtual Announcement IdAnnouncementNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
