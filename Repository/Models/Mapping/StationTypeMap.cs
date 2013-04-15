using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class StationTypeMap : EntityTypeConfiguration<StationType>
    {
        public StationTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("StationTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
