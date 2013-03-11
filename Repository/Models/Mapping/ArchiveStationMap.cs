using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ArchiveStationMap : EntityTypeConfiguration<ArchiveStation>
    {
        public ArchiveStationMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("ArchiveStations");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.ArchiveId).HasColumnName("ArchiveId");
            Property(t => t.StationLat).HasColumnName("StationLat");
            Property(t => t.StationLong).HasColumnName("StationLong");

            // Relationships
            HasRequired(t => t.Archive)
                .WithMany(t => t.ArchiveStations)
                .HasForeignKey(d => d.ArchiveId);
        }
    }
}