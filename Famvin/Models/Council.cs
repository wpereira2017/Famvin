//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Famvin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Council
    {
        public Council()
        {
            this.Member = new HashSet<Member>();
        }
    
        public int IdCouncil { get; set; }
        public int IdRegion { get; set; }

        [Display(Name = "Council")]
        public string Name { get; set; }
    
        public virtual Region Region { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}
