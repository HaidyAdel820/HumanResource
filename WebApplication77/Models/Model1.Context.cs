﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication77.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HumanResourceEntities : DbContext
    {
        public HumanResourceEntities()
            : base("name=HumanResourceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmployeEndanceAndDeparture> EmployeEndanceAndDeparture { get; set; }
        public virtual DbSet<EmployeeSetting> EmployeeSetting { get; set; }
        public virtual DbSet<OfficialHolidays> OfficialHolidays { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserSystem> UserSystem { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Usergroup> Usergroup { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }
    }
}
