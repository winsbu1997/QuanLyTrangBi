namespace QuanLyTrangBi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RepairDiary")]
    public partial class RepairDiary
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeEnd { get; set; }

        [StringLength(250)]
        public string Reason { get; set; }

        [StringLength(250)]
        public string Worker { get; set; }

        [StringLength(100)]
        public string RepairPlace { get; set; }

        [StringLength(100)]
        public string Result { get; set; }

        public int? Equipment_ID { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
