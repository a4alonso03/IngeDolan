//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IngeDolan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class telefono
    {
        public string cedula { get; set; }
        public string telefono1 { get; set; }
    
        public virtual persona persona { get; set; }
        public virtual persona persona1 { get; set; }
    }
}
