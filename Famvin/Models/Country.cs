using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{

    public partial class Country
    {
        public Country()
        {
            Council = new HashSet<Council>();
        }

        public int IdCountry { get; set; }

        [Display(Name = "Region")]
        public int IdRegion { get; set; }


        [Display(Name = "Country")]
        public string Name { get; set; }
        public string HighMapCode { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Council> Council { get; set; }
    }
}