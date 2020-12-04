using System;
using System.Collections.Generic;

namespace Famvin.Models
{

    public partial class Region
    {
        public Region()
        {
            this.Council = new HashSet<Council>();
            this.Country = new HashSet<Country>();
            this.Member = new HashSet<Member>();
        }

        public int IdRegion { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Council> Council { get; set; }
        public virtual ICollection<Country> Country { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }

}
