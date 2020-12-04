using System;
using System.Collections.Generic;

namespace Famvin.Models
{
    public partial class Member
    {
        public int IdMember { get; set; }
        public int IdRegion { get; set; }
        public int IdCouncil { get; set; }
        public int IdPosition1 { get; set; }
        public int IdOccupation { get; set; }
        public int IdBranch { get; set; }
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