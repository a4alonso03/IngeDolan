
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
    
public partial class USER
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public USER()
    {

        this.PROJECTs = new HashSet<PROJECT>();

        this.TASKs = new HashSet<TASK>();

    }


    public int USERS_ID { get; set; }

    public string ROLE_TYPE { get; set; }

    public string EMAIL { get; set; }

    public string USERNAME { get; set; }

    public string SURNAME { get; set; }

    public string LASTNAME { get; set; }

    public string PASSWORDS { get; set; }

    public Nullable<int> PROJECT_ID { get; set; }

    public bool REMEMBER { get; set; }

    public string sys_user_id { get; set; }

    public string STUDENT_ID { get; set; }

    public virtual AspNetUser AspNetUser { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<PROJECT> PROJECTs { get; set; }

    public virtual PROJECT PROJECT { get; set; }

    public virtual ROLE ROLE { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TASK> TASKs { get; set; }

}

}
