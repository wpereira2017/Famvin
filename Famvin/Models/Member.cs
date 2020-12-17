using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{
    public partial class Member
    {
        public int IdMember { get; set; }

        [Display(Name = "Region")]
        public int IdRegion { get; set; }

        [Display(Name = "Council")]
        public int IdCouncil { get; set; }

        [Display(Name = "Position 1")]
        public int IdPosition1 { get; set; }

        [Display(Name = "Occupation")]
        public int IdOccupation { get; set; }


        [Display(Name = "Branch")]
        public int IdBranch { get; set; }


        [Display(Name = "Position 2")]
        public Nullable<int> IdPosition2 { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Council Council { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Position Position { get; set; }
        public virtual Region Region { get; set; }
    }
}
