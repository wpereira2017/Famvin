using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Famvin.Models
{
    public partial class Country
    {
        public int IdCountry { get; set; }

        [Display(Name = "Region")]
        public int IdRegion { get; set; }

        [Display(Name = "Country")]
        public string Name { get; set; }

        public virtual Region Region { get; set; }
    }
}
