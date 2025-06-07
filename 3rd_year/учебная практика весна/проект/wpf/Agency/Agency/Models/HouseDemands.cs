namespace Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HouseDemands
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? MinFloors { get; set; }

        public int? MaxFloors { get; set; }

        public double? MinArea { get; set; }

        public double? MaxArea { get; set; }

        public int? MinRooms { get; set; }

        public int? MaxRooms { get; set; }

        public int Demand_Id { get; set; }

        public virtual Demands Demands { get; set; }
    }
}
