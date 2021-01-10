using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{

    public partial class Council
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Council()
        {
            Member = new HashSet<Member>();
        }

        public int IdCouncil { get; set; }

        [Display(Name = "Region")]
        public int IdRegion { get; set; }


        [Display(Name = "Country")]
        public int IdCountry { get; set; }


        [Display(Name = "Council")]
        public string Name { get; set; }


        public virtual Region Region { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}