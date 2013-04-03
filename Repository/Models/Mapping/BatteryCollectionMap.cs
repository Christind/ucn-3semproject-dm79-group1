using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryCollectionMap : EntityTypeConfiguration<BatteryCollection>
    {
        public BatteryCollectionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("BatteryCollection");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BatteryStorageId).HasColumnName("BatteryStorageId");
            this.Property(t => t.BatteryId).HasColumnName("BatteryId");

            // Relationships
            this.HasRequired(t => t.Battery)
                .WithMany(t => t.BatteryCollections)
                .HasForeignKey(d => d.BatteryId);
            this.HasRequired(t => t.BatteryStorage)
                .WithMany(t => t.BatteryCollections)
                .HasForeignKey(d => d.BatteryStorageId);

        }
    }
}
