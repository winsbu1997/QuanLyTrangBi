namespace QuanLyTrangBi.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Databse : DbContext
    {
        public Databse()
            : base("name=Databse")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BranchGroup> BranchGroups { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<GroupTransferDiary> GroupTransferDiaries { get; set; }
        public virtual DbSet<MaintainDiary> MaintainDiaries { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<RepairDiary> RepairDiaries { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchGroup>()
                .HasMany(e => e.Equipments)
                .WithOptional(e => e.BranchGroup)
                .HasForeignKey(e => e.BranchGroup_ID);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.GroupTransferDiaries)
                .WithOptional(e => e.Equipment)
                .HasForeignKey(e => e.Equipment_ID);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.MaintainDiaries)
                .WithOptional(e => e.Equipment)
                .HasForeignKey(e => e.Equipment_ID);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.Parameters)
                .WithOptional(e => e.Equipment)
                .HasForeignKey(e => e.Equipment_ID);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.RepairDiaries)
                .WithOptional(e => e.Equipment)
                .HasForeignKey(e => e.Equipment_ID);

            modelBuilder.Entity<EquipmentType>()
                .HasMany(e => e.Equipments)
                .WithOptional(e => e.EquipmentType)
                .HasForeignKey(e => e.EquipmentType_ID);
        }
    }
}
