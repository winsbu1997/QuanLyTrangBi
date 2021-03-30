namespace QuanLyTrangBi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupTransferDiary")]
    public partial class GroupTransferDiary
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Time { get; set; }

        public int? GroupFrom { get; set; }

        public int? GroupTo { get; set; }

        public int? Equipment_ID { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
