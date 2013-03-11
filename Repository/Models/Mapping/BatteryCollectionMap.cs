using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryCollectionMap : EntityTypeConfiguration<BatteryCollection>
    {
        public BatteryCollectionMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("BatteryCollection");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.BatteryStorageId).HasColumnName("BatteryStorageId");
            Property(t => t.BatteryId).HasColumnName("BatteryId");

            // Relationships
            //this.HasRequired(t => t.Battery)
            //    .WithMany(t => t.BatteryCollections)
            //    .HasForeignKey(d => d.BatteryId);
            HasRequired(t => t.BatteryStorage)
                .WithMany(t => t.BatteryCollections)
                .HasForeignKey(d => d.BatteryStorageId);
        }
    }
}