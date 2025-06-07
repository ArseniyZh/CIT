namespace Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Demands
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demands()
        {
            ApartmentDemands = new HashSet<ApartmentDemands>();
            HouseDemands = new HashSet<HouseDemands>();
            LandDemands = new HashSet<LandDemands>();
            Supplies = new HashSet<Supplies>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Address_City { get; set; }

        [StringLength(255)]
        public string Address_Street { get; set; }

        [StringLength(50)]
        public string Address_House { get; set; }

        [StringLength(50)]
        public string Address_Number { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        public int AgentId { get; set; }

        public int ClientId { get; set; }

        [NotMapped]
        public string DisplayInfo { get; set; }

        public virtual Agents Agents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApartmentDemands> ApartmentDemands { get; set; }

        public virtual Clients Clients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseDemands> HouseDemands { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LandDemands> LandDemands { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplies> Supplies { get; set; }
    }
}
