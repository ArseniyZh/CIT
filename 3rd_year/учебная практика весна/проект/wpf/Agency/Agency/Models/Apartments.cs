namespace Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apartments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public double? Coordinate_latitude { get; set; }

        public double? Coordinate_longitude { get; set; }

        public double? TotalArea { get; set; }

        public int? Rooms { get; set; }

        public int? Floor { get; set; }

        public int RealEstate_Id { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}
