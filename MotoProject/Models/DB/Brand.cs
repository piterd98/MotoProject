using System;
using System.Collections.Generic;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public int IdBrand { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
