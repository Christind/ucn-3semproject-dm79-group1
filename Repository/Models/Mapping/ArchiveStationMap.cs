using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ArchiveStationMap : EntityTypeConfiguration<ArchiveStation>
    {
        public ArchiveStationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ArchiveStations");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ArchiveId).HasColumnName("ArchiveId");
            this.Property(t => t.StationLat).HasColumnName("StationLat");
            this.Property(t => t.StationLong).HasColumnName("StationLong");

            // Relationships
            this.HasRequired(t => t.Archive)
                .WithMany(t => t.ArchiveStations)
                .HasForeignKey(d => d.ArchiveId);

        }
    }
}
