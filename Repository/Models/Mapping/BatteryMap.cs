using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BatteryMap : EntityTypeConfiguration<Battery>
    {
        public BatteryMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Serial)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            ToTable("Batteries");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Serial).HasColumnName("Serial");
            Property(t => t.ManufacturingDate).HasColumnName("ManufacturingDate");
            Property(t => t.OutOfCommisionDate).HasColumnName("OutOfCommisionDate");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}