using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{
    
    public partial class Region
    {
        public Region()
        {
            Council = new HashSet<Council>();
            Country = new HashSet<Country>();
            Member = new HashSet<Member>();
        }
    
        public int IdRegion { get; set; }

        [Display(Name = "Region")]
        public string Name { get; set; }
    
        public virtual ICollection<Council> Council { get; set; }
        public virtual ICollection<Country> Country { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}
