using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ManufacturerMap : EntityTypeConfiguration<Manufacturer>
    {
        public ManufacturerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Website)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Manufacturers");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Website).HasColumnName("Website");
        }
    }
}
