using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class Bill
    {
        public int IdBill { get; set; }
        public int IdService { get; set; }
        public int IdAnnouncement { get; set; }
        public int IdUser { get; set; }
        public decimal FinalValue { get; set; }
        public DateTime DateTo { get; set; }

        public virtual Announcement IdAnnouncementNavigation { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
    }
}
