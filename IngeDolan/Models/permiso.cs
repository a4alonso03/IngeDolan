
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
    
public partial class permiso
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public permiso()
    {

        this.permisos_asociados_roles = new HashSet<permisos_asociados_roles>();

        this.permisos_asociados_roles1 = new HashSet<permisos_asociados_roles>();

    }


    public int id_permiso { get; set; }

    public string permiso1 { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<permisos_asociados_roles> permisos_asociados_roles { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<permisos_asociados_roles> permisos_asociados_roles1 { get; set; }

}

}
