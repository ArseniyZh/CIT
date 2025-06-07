namespace Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplies()
        {
            Demands = new HashSet<Demands>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public double Price { get; set; }

        public int AgentId { get; set; }

        public int ClientId { get; set; }

        public int RealEstate_Id { get; set; }
        [NotMapped]
        public string DisplayInfo { get; set; }

        public virtual Agents Agents { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual RealEstate RealEstate { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Demands> Demands { get; set; }
    }
}
