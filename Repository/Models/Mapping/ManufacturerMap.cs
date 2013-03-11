using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ManufacturerMap : EntityTypeConfiguration<Manufacturer>
    {
        public ManufacturerMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);

            Property(t => t.Website)
                .HasMaxLength(128);

            // Table & Column Mappings
            ToTable("Manufacturers");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Website).HasColumnName("Website");
        }
    }
}