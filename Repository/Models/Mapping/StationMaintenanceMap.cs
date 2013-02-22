using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class StationMaintenanceMap : EntityTypeConfiguration<StationMaintenance>
    {
        public StationMaintenanceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("StationMaintenances");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.StationId).HasColumnName("StationId");
            this.Property(t => t.ExpectedOperationalDate).HasColumnName("ExpectedOperationalDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasRequired(t => t.MaintenanceType)
                .WithMany(t => t.StationMaintenances)
                .HasForeignKey(d => d.TypeId);
            this.HasRequired(t => t.Station)
                .WithMany(t => t.StationMaintenances)
                .HasForeignKey(d => d.StationId);

        }
    }
}
