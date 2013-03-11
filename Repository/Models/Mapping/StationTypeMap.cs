using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class StationTypeMap : EntityTypeConfiguration<StationType>
    {
        public StationTypeMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            ToTable("StationTypes");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}