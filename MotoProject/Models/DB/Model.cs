using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class Model
    {
        public Model()
        {
            Announcements = new HashSet<Announcement>();
        }

        public int IdModel { get; set; }
        public int IdBrand { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual Brand IdBrandNavigation { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
