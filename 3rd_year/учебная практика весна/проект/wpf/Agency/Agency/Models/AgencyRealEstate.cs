using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Agency.Models
{
    public partial class AgencyRealEstate : DbContext
    {
        public AgencyRealEstate()
            : base("name=AgencyRealEstate")
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<ApartmentDemands> ApartmentDemands { get; set; }
        public virtual DbSet<Apartments> Apartments { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Demands> Demands { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<HouseDemands> HouseDemands { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<LandDemands> LandDemands { get; set; }
        public virtual DbSet<Lands> Lands { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<RealEstate> RealEstate { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>()
                .Property(e => e.Address_City)
                .IsUnicode(false);

            modelBuilder.Entity<Addresses>()
                .Property(e => e.Address_Street)
                .IsUnicode(false);

            modelBuilder.Entity<Addresses>()
                .Property(e => e.Address_House)
                .IsUnicode(false);

            modelBuilder.Entity<Addresses>()
                .Property(e => e.Address_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Addresses>()
                .HasMany(e => e.RealEstate)
                .WithRequired(e => e.Addresses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agents>()
                .HasMany(e => e.Demands)
                .WithRequired(e => e.Agents)
                .HasForeignKey(e => e.AgentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Agents>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.Agents)
                .HasForeignKey(e => e.AgentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Demands)
                .WithRequired(e => e.Clients)
                .HasForeignKey(e => e.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.Clients)
                .HasForeignKey(e => e.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demands>()
                .Property(e => e.Address_City)
                .IsUnicode(false);

            modelBuilder.Entity<Demands>()
                .Property(e => e.Address_Street)
                .IsUnicode(false);

            modelBuilder.Entity<Demands>()
                .Property(e => e.Address_House)
                .IsUnicode(false);

            modelBuilder.Entity<Demands>()
                .Property(e => e.Address_Number)
                .IsUnicode(false);

            modelBuilder.Entity<Demands>()
                .HasMany(e => e.ApartmentDemands)
                .WithRequired(e => e.Demands)
                .HasForeignKey(e => e.Demand_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demands>()
                .HasMany(e => e.HouseDemands)
                .WithRequired(e => e.Demands)
                .HasForeignKey(e => e.Demand_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demands>()
                .HasMany(e => e.LandDemands)
                .WithRequired(e => e.Demands)
                .HasForeignKey(e => e.Demand_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demands>()
                .HasMany(e => e.Supplies)
                .WithMany(e => e.Demands)
                .Map(m => m.ToTable("Deals").MapLeftKey("Demand_Id").MapRightKey("Supply_Id"));

            modelBuilder.Entity<Districts>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Districts>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Districts>()
                .HasMany(e => e.Addresses)
                .WithOptional(e => e.Districts)
                .HasForeignKey(e => e.District_Id);

            modelBuilder.Entity<Persons>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .HasOptional(e => e.Agents)
                .WithRequired(e => e.Persons)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Persons>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Persons)
                .HasForeignKey(e => e.Person_Id);

            modelBuilder.Entity<RealEstate>()
                .Property(e => e.RealEstateType)
                .IsUnicode(false);

            modelBuilder.Entity<RealEstate>()
                .HasMany(e => e.Apartments)
                .WithRequired(e => e.RealEstate)
                .HasForeignKey(e => e.RealEstate_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RealEstate>()
                .HasMany(e => e.Houses)
                .WithRequired(e => e.RealEstate)
                .HasForeignKey(e => e.RealEstate_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RealEstate>()
                .HasMany(e => e.Lands)
                .WithRequired(e => e.RealEstate)
                .HasForeignKey(e => e.RealEstate_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RealEstate>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.RealEstate)
                .HasForeignKey(e => e.RealEstate_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Persons)
                .WithOptional(e => e.Roles)
                .WillCascadeOnDelete();
        }
    }
}
