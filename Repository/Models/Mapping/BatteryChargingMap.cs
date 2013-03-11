using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryChargingMap : EntityTypeConfiguration<BatteryCharging>
    {
        public BatteryChargingMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("BatteryCharging");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.BatteryId).HasColumnName("BatteryId");
            Property(t => t.EstimatedTime).HasColumnName("EstimatedTime");
            Property(t => t.CompletedTime).HasColumnName("CompletedTime");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            //this.HasRequired(t => t.Battery)
            //    .WithMany(t => t.BatteryChargings)
            //    .HasForeignKey(d => d.BatteryId);
        }
    }
}