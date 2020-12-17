using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{
    
    public partial class Branch
    {
        public Branch()
        {
            Member = new HashSet<Member>();
        }
    
        public int IdBranch { get; set; }
        public string Code { get; set; }
        
        [Display(Name = "Branch")]
        public string Name { get; set; }
    
        public virtual ICollection<Member> Member { get; set; }
    }
}
