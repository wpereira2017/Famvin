using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{
    public partial class Position
    {
        public Position()
        {
            this.Member = new HashSet<Member>();
        }
    
        public int IdPosition { get; set; }

        [Display(Name = "Position")]
        public string Name { get; set; }
    
        public virtual ICollection<Member> Member { get; set; }
    }
}
