using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryChargingMap : EntityTypeConfiguration<BatteryCharging>
    {
        public BatteryChargingMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("BatteryCharging");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BatteryId).HasColumnName("BatteryId");
            this.Property(t => t.EstimatedTime).HasColumnName("EstimatedTime");
            this.Property(t => t.CompletedTime).HasColumnName("CompletedTime");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Battery)
                .WithMany(t => t.BatteryChargings)
                .HasForeignKey(d => d.BatteryId);

        }
    }
}
