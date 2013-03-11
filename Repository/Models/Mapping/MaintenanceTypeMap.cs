using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class MaintenanceTypeMap : EntityTypeConfiguration<MaintenanceType>
    {
        public MaintenanceTypeMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            ToTable("MaintenanceTypes");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}