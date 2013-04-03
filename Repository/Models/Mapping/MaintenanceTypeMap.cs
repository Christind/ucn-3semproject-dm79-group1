using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class MaintenanceTypeMap : EntityTypeConfiguration<MaintenanceType>
    {
        public MaintenanceTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("MaintenanceTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
