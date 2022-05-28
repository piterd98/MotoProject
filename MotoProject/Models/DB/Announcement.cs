using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class Announcement
    {
        public Announcement()
        {
            Bills = new HashSet<Bill>();
            Messages = new HashSet<Message>();
        }

        public int IdAnnouncement { get; set; }
        public int IdUser { get; set; }
        public int IdBrand { get; set; }
        public int IdModel { get; set; }
        public int IdBodyType { get; set; }
        public int IdColor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Negotiable { get; set; }
        public int? ProDate { get; set; }
        public int? Mileage { get; set; }
        public int? StrokeCapacity { get; set; }
        public int? Power { get; set; }
        public bool IsActive { get; set; }

        public virtual BodyType IdBodyTypeNavigation { get; set; }
        public virtual Color IdColorNavigation { get; set; }
        public virtual Model IdModelNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
