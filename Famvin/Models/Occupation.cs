using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{
    public partial class Occupation
    {
        public Occupation()
        {
            Member = new HashSet<Member>();
        }
    
        public int IdOccupation { get; set; }

        [Display(Name = "Occupation")]
        public string Name { get; set; }
    
        public virtual ICollection<Member> Member { get; set; }
    }
}
