﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputerShop.model.database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComputerShopContext : DbContext
    {
        public ComputerShopContext()
            : base("name=ComputerShopContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<DeliveredToWareHouse> DeliveredToWareHouse { get; set; }
        public virtual DbSet<Ordered> Ordered { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}