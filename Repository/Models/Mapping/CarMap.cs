using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Cars");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.ModelId).HasColumnName("ModelId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasRequired(t => t.CarModel)
                .WithMany(t => t.Cars)
                .HasForeignKey(d => d.ModelId);
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Cars)
                .HasForeignKey(d => d.ManufacturerId);

        }
    }
}
