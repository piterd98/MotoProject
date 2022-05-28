using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class Color
    {
        public Color()
        {
            Announcements = new HashSet<Announcement>();
        }

        public int IdColor { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
