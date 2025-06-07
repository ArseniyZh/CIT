namespace Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Addresses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addresses()
        {
            RealEstate = new HashSet<RealEstate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Address_Id { get; set; }

        [StringLength(255)]
        public string Address_City { get; set; }

        [StringLength(255)]
        public string Address_Street { get; set; }

        [StringLength(50)]
        public string Address_House { get; set; }

        [StringLength(50)]
        public string Address_Number { get; set; }

        public int? District_Id { get; set; }

        public virtual Districts Districts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RealEstate> RealEstate { get; set; }
    }
}
