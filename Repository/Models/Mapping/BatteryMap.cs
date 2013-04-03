using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryMap : EntityTypeConfiguration<Battery>
    {
        public BatteryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Serial)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Batteries");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.ManufacturingDate).HasColumnName("ManufacturingDate");
            this.Property(t => t.OutOfCommisionDate).HasColumnName("OutOfCommisionDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
