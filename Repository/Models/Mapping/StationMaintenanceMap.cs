using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class StationMaintenanceMap : EntityTypeConfiguration<StationMaintenance>
    {
        public StationMaintenanceMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("StationMaintenances");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.TypeId).HasColumnName("TypeId");
            Property(t => t.StationId).HasColumnName("StationId");
            Property(t => t.ExpectedOperationalDate).HasColumnName("ExpectedOperationalDate");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            HasRequired(t => t.MaintenanceType)
                .WithMany(t => t.StationMaintenances)
                .HasForeignKey(d => d.TypeId);
            //this.HasRequired(t => t.Station)
            //    .WithMany(t => t.StationMaintenances)
            //    .HasForeignKey(d => d.StationId);
        }
    }
}