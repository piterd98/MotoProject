using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class Service
    {
        public Service()
        {
            Bills = new HashSet<Bill>();
        }

        public int IdService { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
