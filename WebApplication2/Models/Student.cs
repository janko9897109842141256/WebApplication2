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
    
    public partial class Student
    {
        public Student()
        {
            this.Ispits = new HashSet<Ispit>();
        }
    
        public int BI { get; set; }
        public int Grupa_ID { get; set; }
        public string Ime_Prezime { get; set; }
        public int Godina_Studija { get; set; }
        public System.DateTime Datum_Rodjenja { get; set; }
        public string Grad { get; set; }
    
        public virtual ICollection<Ispit> Ispits { get; set; }
    }
}
