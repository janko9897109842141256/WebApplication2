//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Predmet
    {
        public Predmet()
        {
            this.Ispits = new HashSet<Ispit>();
        }
    
        public int Predmet_ID { get; set; }
        public string Naziv_Predmeta { get; set; }
    
        public virtual ICollection<Ispit> Ispits { get; set; }
    }
}