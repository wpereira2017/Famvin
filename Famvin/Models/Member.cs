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
        public virtual Member Member1 { get; set; }
        public virtual Member Member2 { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Position Position { get; set; }
        public virtual Region Region { get; set; }
    }
}
