namespace QuanLyTrangBi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parameter")]
    public partial class Parameter
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Value { get; set; }

        [StringLength(50)]
        public string Unit { get; set; }

        public int? Equipment_ID { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
