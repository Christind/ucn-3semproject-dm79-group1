using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("Cars");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            Property(t => t.ModelId).HasColumnName("ModelId");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            HasRequired(t => t.CarModel)
                .WithMany(t => t.Cars)
                .HasForeignKey(d => d.ModelId);
            HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Cars)
                .HasForeignKey(d => d.ManufacturerId);
        }
    }
}