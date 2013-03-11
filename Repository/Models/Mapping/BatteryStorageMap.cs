using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryStorageMap : EntityTypeConfiguration<BatteryStorage>
    {
        public BatteryStorageMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("BatteryStorage");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.StationId).HasColumnName("StationId");
            Property(t => t.Available).HasColumnName("Available");
            Property(t => t.Reserved).HasColumnName("Reserved");
            Property(t => t.Charging).HasColumnName("Charging");

            // Relationships
            HasRequired(t => t.Station)
                .WithMany(t => t.BatteryStorages)
                .HasForeignKey(d => d.StationId);
        }
    }
}