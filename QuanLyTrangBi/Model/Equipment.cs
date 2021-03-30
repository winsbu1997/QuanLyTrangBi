namespace QuanLyTrangBi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public partial class Equipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipment()
        {
            GroupTransferDiaries = new HashSet<GroupTransferDiary>();
            MaintainDiaries = new HashSet<MaintainDiary>();
            Parameters = new HashSet<Parameter>();
            RepairDiaries = new HashSet<RepairDiary>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string KeyEquip { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WorkBegin { get; set; }

        [StringLength(50)]
        public string WorkMaxOrigin { get; set; }

        [StringLength(50)]
        public string WorkmaxNow { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? Subtitute { get; set; }

        public int? EquipmentGroup { get; set; }

        public int? EquipmentType_ID { get; set; }

        public int? BranchGroup_ID { get; set; }

        public virtual BranchGroup BranchGroup { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupTransferDiary> GroupTransferDiaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintainDiary> MaintainDiaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parameter> Parameters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RepairDiary> RepairDiaries { get; set; }
    }
}
