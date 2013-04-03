using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryStorageMap : EntityTypeConfiguration<BatteryStorage>
    {
        public BatteryStorageMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("BatteryStorage");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StationId).HasColumnName("StationId");
            this.Property(t => t.Available).HasColumnName("Available");
            this.Property(t => t.Reserved).HasColumnName("Reserved");
            this.Property(t => t.Charging).HasColumnName("Charging");

            // Relationships
            this.HasRequired(t => t.Station)
                .WithMany(t => t.BatteryStorages)
                .HasForeignKey(d => d.StationId);

        }
    }
}
