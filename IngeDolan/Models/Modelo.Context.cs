﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dolansoftEntities : DbContext
    {
        public dolansoftEntities()
            : base("name=dolansoftEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BACKLOG> BACKLOGs { get; set; }
        public virtual DbSet<EXTERNAL_LOGIN> EXTERNAL_LOGIN { get; set; }
        public virtual DbSet<MILESTONE> MILESTONEs { get; set; }
        public virtual DbSet<permiso> permisos { get; set; }
        public virtual DbSet<permisos_asociados_roles> permisos_asociados_roles { get; set; }
        public virtual DbSet<PERMISSION> PERMISSIONs { get; set; }
        public virtual DbSet<persona> personas { get; set; }
        public virtual DbSet<PROJECT> PROJECTs { get; set; }
        public virtual DbSet<ROLE> ROLES { get; set; }
        public virtual DbSet<SCENARIO> SCENARIOs { get; set; }
        public virtual DbSet<SPRINT> SPRINTs { get; set; }
        public virtual DbSet<TASK> TASKs { get; set; }
        public virtual DbSet<telefono> telefonoes { get; set; }
        public virtual DbSet<USER_STORY> USER_STORY { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
    }
}
